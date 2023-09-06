using DesignPattern.Iterator.IteratorPattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Iterator.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            VisitRouteMover visitRouteMover = new VisitRouteMover();

            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Almanya", CityName = "Berlin", VisitPlaceName = "Berlin kapısı" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Fransa", CityName = "Paris", VisitPlaceName = "Eyfel" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "İtalya", CityName = "Venedik", VisitPlaceName = "Gondol" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "İtalya", CityName = "Roma", VisitPlaceName = "Kolezyum" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Çek", CityName = "Prag", VisitPlaceName = "Meydan" });

            var iterator = visitRouteMover.CreateIterator();

            List<string> strings = new List<string>();

            while (iterator.NextLocation())
            {
                strings.Add(iterator.CurrentItem.CountryName + " " + iterator.CurrentItem.CityName);
            }
            ViewBag.v = strings;

            return View();
        }
    }
}