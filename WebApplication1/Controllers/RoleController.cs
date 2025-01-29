using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly Context context;
        private readonly IUserRepo userRepo;
        private readonly UserManager<ApplicationUser> userManager;


        public RoleController(RoleManager<IdentityRole> roleManager,
            Context context,
            IUserRepo userRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.userRepo = userRepo;
            this.userManager = userManager;
        }

        public IActionResult index()
        {
            var role = context.Roles.ToList();
            ViewBag.Role = role;
            return View(ViewBag);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.rolename;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded == true)
                {
                    ViewBag.sucess = true;
                    return View("create");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Create", roleViewModel);
        }

        private List<SelectListItem> GetRoles()
        {
            var lstRoles = new List<SelectListItem>();

            lstRoles = context.Roles.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.Name
            }).ToList();

            var dmyItem = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Role ---"
            };

            lstRoles.Insert(0, dmyItem);

            return lstRoles;
        }
        public IActionResult Edit(string name)
        {
            var role = context.Roles.FirstOrDefault(x => x.Name == name);
            var roleViewModel = new RoleViewModel { rolename = name };
            return View(roleViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(RoleViewModel newrole, string name)
        {
            if (ModelState.IsValid)
            {

                var role = context.Roles.FirstOrDefault(x => x.Name == name);
                if (role != null)
                {
                    role.Name = newrole.rolename;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View("Edit", newrole);
        }

        public async Task<IActionResult> AssignRole()
        {
            ViewBag.selectList = GetRoles();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>AssignRole(UserRoleViewModel userRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userRoleViewModel.name);
                var role = context.Roles.Find(userRoleViewModel.roleid);
                await userManager.AddToRoleAsync(user, role.Name);
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("AssignRole",userRoleViewModel);
        }
       
    }
}
