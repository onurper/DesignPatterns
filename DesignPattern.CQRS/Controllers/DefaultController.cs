using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _handler;
        private readonly CreateProductCommandHandler _command;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductCommandHandler removeProductCommand;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler updateProductCommand;

        public DefaultController(GetProductQueryHandler handler, CreateProductCommandHandler command, GetProductByIdQueryHandler getProductByIdQueryHandler, RemoveProductCommandHandler removeProductCommand, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommand)
        {
            _handler = handler;
            _command = command;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            this.removeProductCommand = removeProductCommand;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            this.updateProductCommand = updateProductCommand;
        }

        public IActionResult Index()
        {
            var values = _handler.Handle();
            return View(values);
        }

        public IActionResult GetProduct(int id)
        {
            var values = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(values);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand createProduct)
        {
            _command.Handle(createProduct);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            removeProductCommand.Handle(new RemoveProductCommand { Id = id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            updateProductCommand.Handle(command);
            return RedirectToAction("Index");
        }
    }
}