using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;
using System;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context context;

        public RemoveProductCommandHandler(Context context)
        {
            this.context = context;
        }

        public void Handle(RemoveProductCommand command)
        {
            try
            {
                var values = context.Products.Find(command.Id);
                context.Products.Remove(values);
                context.SaveChanges();

                Product product = new Product
                {
                    ProductId = 11,
                    Price = 222,
                    Stock = 2,
                    Status = true,
                    Description = "Test",
                    Name = "Test 1"
                };
                context.Remove(product);
                context.SaveChanges();

                Product valuess = context.Products.Find(12);
                context.Remove(valuess);
                context.SaveChanges();
            }
            catch (Exception Ex)
            {
                _ = Ex.Message;
                throw;
            }
        }
    }
}