using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View(categoryRepo.GetAll());
        }

        public ActionResult AllProducts(int id)
        {
            return View(categoryRepo.GetProducts(id));
        }
        public ActionResult Details(int id)
        {
            var category= categoryRepo.GetByID(id);
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Name = category.Name;
            viewModel.Description = category.Description;
            viewModel.Id= id;
            return View(viewModel);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            CategoryViewModel product = new CategoryViewModel();

            return View(product);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryRepo.Add(category);
                categoryRepo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("create",category);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category=categoryRepo.GetByID(id);
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Name = category.Name;
            viewModel.Description = category.Description;
            viewModel.Id = id;
            return View(viewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
               categoryRepo.Update(category);
                categoryRepo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit",category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category= categoryRepo.GetByID(id);
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Name = category.Name;
            viewModel.Description = category.Description;
            return View(viewModel);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                categoryRepo.Delete(category);
                categoryRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return RedirectToAction("delete", category);
            }
        }
    }
}
