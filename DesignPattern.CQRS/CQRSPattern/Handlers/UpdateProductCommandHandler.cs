using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand updateProduct)
        {
            var values = _context.Products.Find(updateProduct.Id);
            if (values != null)
            {
                values.ProductId = updateProduct.Id;
                values.Price = updateProduct.Price;
                values.Status = true;
                values.Name = updateProduct.Name;
                values.Description = updateProduct.Description;
                values.Stock = updateProduct.Stock;
                _context.SaveChanges();
            }
        }
    }
}