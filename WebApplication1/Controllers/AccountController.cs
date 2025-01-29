using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICartRepo cartRepo;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICartRepo cartRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartRepo = cartRepo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "This email is already in use. Please choose a different email.");
                    return View("Register", model);
                }

                var appUser = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    address = model.Address,
                    PhoneNumber = model.phonenumber,
                    fullname = model.UserName
                };

                var id = await userManager.GetUserIdAsync(appUser);
                appUser.CartId = cartRepo.GetOrCreateCartId(id);

                var result = await userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(appUser, isPersistent: false);
                    await userManager.AddToRoleAsync(appUser, "User");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Register");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = await userManager.FindByNameAsync(user.Name);
                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, user.Password);
                    if (found)
                    {
                        List<Claim> Claims = new List<Claim>
                        {
                            new Claim("UserAddress", appUser.address),
                            new Claim("CartId", appUser.CartId.ToString())
                        };


                        await signInManager.SignInAsync(appUser, user.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Username OR Password is incorrect");
            }

            return View("Login", user);
        }

        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete("CartId");
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.ApplicationScheme);

            if (result?.Principal != null)
            {
                var email = result.Principal.FindFirstValue(ClaimTypes.Email);
                var name = result.Principal.FindFirstValue(ClaimTypes.Name);
                var externalId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

                var existingUser = await userManager.FindByEmailAsync(email);

                if (existingUser == null)
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = name,
                        Email = email,
                        fullname = name
                    };

                    newUser.CartId = cartRepo.GetOrCreateCartId(newUser.Id);

                    var loginResult = await userManager.CreateAsync(newUser);
                    await userManager.AddToRoleAsync(newUser, "User");

                    if (!loginResult.Succeeded)
                    {
                        return RedirectToAction("GoogleLogin");
                    }
                }
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("GoogleLogin");
        }

        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") });
        }
    }
}
