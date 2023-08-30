using DesignPattern.TemplateMethod.TemplatePattern;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.TemplateMethod.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult BasicPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();

            ViewBag.v1 = netflixPlans.PlanType("Temel Plan");
            ViewBag.v2 = netflixPlans.CountPerson(1);
            ViewBag.v3 = netflixPlans.Resolution("480px");
            ViewBag.v4 = netflixPlans.Price(65.99);
            ViewBag.v5 = netflixPlans.Content("Film, Dizi");

            return View();
        }

        public IActionResult StandartPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();

            ViewBag.v1 = netflixPlans.PlanType("Standart Plan");
            ViewBag.v2 = netflixPlans.CountPerson(2);
            ViewBag.v3 = netflixPlans.Resolution("720px");
            ViewBag.v4 = netflixPlans.Price(100.99);
            ViewBag.v5 = netflixPlans.Content("Film, Dizi");

            return View();
        }
        public IActionResult UltraPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();

            ViewBag.v1 = netflixPlans.PlanType("Ultra Plan");
            ViewBag.v2 = netflixPlans.CountPerson(4);
            ViewBag.v3 = netflixPlans.Resolution("1080px");
            ViewBag.v4 = netflixPlans.Price(120.99);
            ViewBag.v5 = netflixPlans.Content("Film, Dizi");

            return View();
        }
    }
}
