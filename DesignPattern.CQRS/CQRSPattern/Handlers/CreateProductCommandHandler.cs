using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand createProduct)
        {
            _context.Products.Add(new Product
            {
                Description = createProduct.Description,
                Name = createProduct.Name,
                Price = createProduct.Price,
                Status = true,
                Stock = createProduct.Stock
            });
            _context.SaveChanges();
        }
    }
}