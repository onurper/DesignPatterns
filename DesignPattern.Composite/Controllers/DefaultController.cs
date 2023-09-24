using DesignPattern.Composite.CompositePattern;
using DesignPattern.Composite.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var valeus = _context.Categories.ToList();
            var categories = _context.Categories.Include(x => x.Products).ToList();

            var values = Rekursive(categories, new Category
            {
                Name = "1. Category",
                Id = 0
            }, new ProductComposite(0, "1. Composite"));

            ViewBag.v = values;
            return View();
        }

        public ProductComposite Rekursive(List<Category> categories, Category firstCategory, ProductComposite firstComposite, ProductComposite leaf = null)
        {
            categories.Where(x => x.UpperCategoryId == firstCategory.Id).ToList().ForEach(y =>
            {
                var productComposite = new ProductComposite(y.Id, y.Name);

                foreach (var item in y.Products.ToList())
                {
                    productComposite.Add(new ProductComponent(item.Id, item.Name));
                }

                if (leaf != null)
                {
                    leaf.Add(productComposite);
                }
                else
                {
                    firstComposite.Add(productComposite);
                }

                Rekursive(categories, y, firstComposite, productComposite);
            });

            return firstComposite;
        }
    }
}