using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly Context context;
        private readonly IUserRepo userRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManger;

        public ProfileController(Context context,IUserRepo user, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,RoleManager<IdentityRole> roleManger) {
            this.context = context;
            this.userRepo = user;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManger = roleManger;
        }

        public async Task<ActionResult> Info()
        {
            ProfileViewModel user = new ProfileViewModel();

            if (User.Identity.IsAuthenticated)
            {
                // Retrieve external user information
                var externalClaims = User.Claims.ToList(); // Getting all claims for the current user

                // Get the name (email or username) from claims
                var userName = User.Identity.Name ?? externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                // Get email from claims
                var email = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                // Get other data from the claims (optional)
                var phone = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.MobilePhone)?.Value;
                var address = externalClaims.FirstOrDefault(c => c.Type == "address")?.Value; // If address is available as a claim

                var userRepoInfo = userRepo.GetByEmail(email);
                if (userRepoInfo != null)
                {
                    user.Name = userRepoInfo.fullname ?? userName;
                    user.email = email ?? userRepoInfo.Email;
                    user.address = address ?? userRepoInfo.address;
                    user.phone = phone ?? userRepoInfo.PhoneNumber;
                }

                var userRole = await userManager.FindByEmailAsync(email);
                var roles = await userManager.GetRolesAsync(userRole);
                if (roles.Count > 1&&roles.Contains("Admin"))
                {
                    user.role = "Admin";
                }
                else
                user.role = roles.FirstOrDefault(); 
                
            }

            return View(user);
        }


        public async Task<ActionResult> Edit()
        {
            var externalClaims = User.Claims.ToList();
            var email = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var userViewModel = new ProfileViewModel();
            var currentUser = userRepo.GetByEmail(email);
            var role = await userManager.GetRolesAsync(currentUser);
            var rolename = role.FirstOrDefault();
            userViewModel.Name = currentUser.UserName;
            userViewModel.address = currentUser.address;
            userViewModel.email = currentUser.Email;
            userViewModel.phone = currentUser.PhoneNumber;
            userViewModel.role = rolename;
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(ProfileViewModel userViewModel)
        {
            var externalClaims = User.Claims.ToList();
            var email = externalClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (ModelState.IsValid)
            {
                return View(userViewModel); 
            }

            var currentUser = userRepo.GetByEmail(email);
            if (currentUser == null)
            {
                return NotFound(); // Handle case where user is not found
            }

            currentUser.UserName = userViewModel.Name;
            currentUser.address = userViewModel.address;
            currentUser.PhoneNumber = userViewModel.phone;
            currentUser.Email = userViewModel.email;
            currentUser.NormalizedUserName = currentUser.UserName.ToUpper();
            currentUser.NormalizedEmail = currentUser.Email.ToUpper();
                userRepo.update(currentUser); // Assuming Update updates the user object in the repository
                userRepo.save(); // Persist the changes

                var userClaims = await userManager.GetClaimsAsync(currentUser);
                await signInManager.RefreshSignInAsync(currentUser);

                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("Index", "Home", TempData);
            }
        }


    }
