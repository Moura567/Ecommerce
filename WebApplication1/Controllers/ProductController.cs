using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Repository;
using WebApplication1.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepo productRepo;
        private readonly ICategoryRepo categoryRepo;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Context context;

        public ProductController(IProductRepo product,ICategoryRepo categoryRepo,IWebHostEnvironment webHostEnvironment,UserManager<ApplicationUser>userManager,Context context)
        {
            this.productRepo = product;
            this.categoryRepo = categoryRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.context = context;
        }
        [AllowAnonymous]
        public async Task< ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = User.Claims.ToList();
                var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = await userManager.FindByEmailAsync(email);

                var cartId = user.CartId;
                ViewBag.CartId = cartId;
            }
            ViewBag.Caregories = GetCategories();
            return View(productRepo.GetAll());
        }



        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var selected= productRepo.GetByID(id);
            ProductViewModel product = new ProductViewModel();
            product.Name = selected.Name;
            product.Id = selected.Id;
            product.Description = selected.Description;
            product.price = selected.price;
            product.amount= selected.amount;
            product.image = selected.image;
            product.categoryId = selected.categoryId;
            product.categoryname =categoryRepo.GetName(product.categoryId);

            return View(product);
        }

        // GET: ProductController/Create

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Search(string query, int categoryId)
        {
            var products = productRepo.SearchProducts(query, categoryId); // Filter products based on query and category
            return PartialView("_ProductTable", products); // Return the partial view with filtered products
        }


        private List<SelectListItem> GetCategories()
        {
            var lstCategories = new List<SelectListItem>();

            lstCategories = context.categories.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.Name
            }).ToList();

            var dmyItem = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Category ---"
            };

            lstCategories.Insert(0, dmyItem);

            return lstCategories;
        }
[Authorize(Roles = "Admin,Dealer")]

        public ActionResult Create()
        {
            ViewBag.categories = GetCategories();
            ProductViewModel product=new ProductViewModel();
           return View(product);
        }
[Authorize(Roles = "Admin,Dealer")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product product)
        {
           
            string uniname = UploadedFile(product);
            product.image=uniname;
            productRepo.Add(product);
            productRepo.Save();
            return RedirectToAction("index");
        }
     
        private string UploadedFile(product product)
        {
            string uniqueFileName = null;


            if (product.imageuploder != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.imageuploder.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.imageuploder.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: ProductController/Edit/5
[Authorize(Roles = "Admin,Dealer")]

        public ActionResult Edit(int id)
        {
            var product=productRepo.GetByID(id);
            ProductViewModel productViewModel= new ProductViewModel();
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.price = product.price;
            productViewModel.image = product.image;
            productViewModel.amount= product.amount;
            productViewModel.categoryId = product.categoryId;
            productViewModel.Categories = GetCategories();
            return View(productViewModel);
        }

        // POST: ProductController/Edit/5
[Authorize(Roles = "Admin,Dealer")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel product)
        {
            try
            {
                var newproduct = productRepo.GetByID(product.Id);

                if (product.imageuploder != null)
                {
                    newproduct.Name = product.Name;
                    newproduct.Description = product.Description;
                    newproduct.categoryId = product.categoryId;
                    newproduct.amount = product.amount;
                    newproduct.price = product.price;
                    newproduct.imageuploder = product.imageuploder;
                    string uniname = UploadedFile(newproduct);
                    newproduct.image = uniname;
                }
                else
                {
                    newproduct.Name = product.Name;
                    newproduct.Description = product.Description;
                    newproduct.categoryId = product.categoryId;
                    newproduct.amount = product.amount;
                    newproduct.price = product.price;
                }
                productRepo.Update(newproduct);
                    productRepo.Save();
                    return RedirectToAction("index");
                
            }
            catch
            {
                return View("edit",product);
            }
        }

        // GET: ProductController/Delete/5
[Authorize(Roles = "Admin,Dealer")]

        public ActionResult Delete(int id)
        {
            var product = productRepo.GetByID(id);
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.price = product.price;
            productViewModel.image = product.image;
            productViewModel.amount = product.amount;
            productViewModel.imageuploder = product.imageuploder;
            productViewModel.categoryId = product.categoryId;
            productViewModel.categoryname = categoryRepo.GetName(product.categoryId);

            return View(productViewModel);
        }
        public void DeleteFile(product product)
        {
            if (product.image != null)
            {
                string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", product.image);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, product collection)
        {
            try
            {
                var product= productRepo.GetByID(id);
                DeleteFile(product);
                productRepo.Delete(product);
                productRepo.Save();
                return RedirectToAction("index");

            }
            catch
            {
                return View("delete",collection);
            }
        }
    }
}
