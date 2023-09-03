using DesignPattern.UnitOfWork.BusinessLayer.Abstract;
using DesignPattern.UnitOfWork.EntityLayer.Concrete;
using DesignPattern.UnitOfWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService customerService;

        public DefaultController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {
            var senderId = customerService.GetById(customerViewModel.SenderId);
            var receiverId = customerService.GetById(customerViewModel.ReceiverId);

            senderId.Balance -= customerViewModel.Amount;
            receiverId.Balance += customerViewModel.Amount;

            List<Customer> customers = new()
            {
                senderId,
                receiverId
            };

            customerService.MultiUpdate(customers);

            return View();
        }
    }
}