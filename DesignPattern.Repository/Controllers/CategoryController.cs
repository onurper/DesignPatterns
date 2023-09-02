using DesignPattern.Repository.BusinessLayer.Abstract;
using DesignPattern.Repository.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Repository.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = categoryService.GetList();
            return View(values);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryService.Insert(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var result = categoryService.GetById(id);
            categoryService.Delete(result);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int id)
        {
            var result = categoryService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}