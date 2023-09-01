using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Commands;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(2);

            values.Category = request.Category;
            values.Stock = request.Stock;
            values.Price = request.Price;
            values.Type = request.Type;
            values.Name = request.Name;

            await _context.SaveChangesAsync();
        }
    }
}