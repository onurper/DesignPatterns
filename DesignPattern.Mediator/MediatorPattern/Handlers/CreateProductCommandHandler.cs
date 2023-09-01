using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Commands;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly Context context;

        public CreateProductCommandHandler(Context context)
        {
            this.context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await context.Products.AddAsync(new Product
            {
                Category = request.Category,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Type = request.Type,
            });
            await context.SaveChangesAsync();
        }
    }
}