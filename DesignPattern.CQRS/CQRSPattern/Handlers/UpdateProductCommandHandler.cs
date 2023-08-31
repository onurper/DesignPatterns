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

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.Id);
            if (values != null)
            {
                values.ProductId = command.Id;
                values.Price = command.Price;
                values.Status = true;
                values.Name = command.Name;
                values.Description = command.Description;
                values.Stock = command.Stock;
                _context.SaveChanges();
            }
        }
    }
}