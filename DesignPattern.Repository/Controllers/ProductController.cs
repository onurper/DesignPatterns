using DesignPattern.Repository.BusinessLayer.Abstract;
using DesignPattern.Repository.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Repository.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = productService.GetList();
            return View(values);
        }

        public IActionResult Index2()
        {
            var values = productService.ProductListWithCategory();
            return View(values);
        }

        public IActionResult AddProduct()
        {
            List<SelectListItem> category = (from x in categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = x.Id.ToString(),
                                                 Text = x.Name.ToString()
                                             }).ToList();
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productService.Insert(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var result = productService.GetById(id);
            productService.Delete(result);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> category = (from x in categoryService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = x.Id.ToString(),
                                                 Text = x.Name.ToString()
                                             }).ToList();
            ViewBag.Category = category;
            var result = productService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productService.Update(product);
            return RedirectToAction("Index");
        }
    }
}