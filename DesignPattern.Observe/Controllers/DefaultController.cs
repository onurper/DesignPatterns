using DesignPattern.Observe.DAL;
using DesignPattern.Observe.Models;
using DesignPattern.Observe.ObservePattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPattern.Observe.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ObserveObject observeObject;

        public DefaultController(UserManager<AppUser> userManager, ObserveObject observeObject)
        {
            this.userManager = userManager;
            this.observeObject = observeObject;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(RegisterViewModel registerViewModel)
        {
            var appUser = new AppUser
            {
                Name = registerViewModel.Username,
                Surname = registerViewModel.Surname,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Username
            };
            var result = await userManager.CreateAsync(appUser, registerViewModel.Password);
            if (result.Succeeded)
            {
                observeObject.NotifyObserve(appUser);
            }
            return View();
        }
    }
}