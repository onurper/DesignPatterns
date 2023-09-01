using DesignPattern.Mediator.MediatorPattern.Commands;
using DesignPattern.Mediator.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Mediator.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMediator mediator;

        public DefaultController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await mediator.Send(new GetAllProductQuery());
            return View(values);
        }

        public async Task<IActionResult> GetProduct(int id)
        {
            var values = await mediator.Send(new GetProductByIdQuery(id));
            return View(values);
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            await mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = await mediator.Send(new GetProductUpdateByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductByIdCommand)
        {
            await mediator.Send(updateProductByIdCommand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand create)
        {
            await mediator.Send(create);
            return RedirectToAction("Index");
        }
    }
}