using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class GetProductUpdateByIdQueryHandler : IRequestHandler<GetProductUpdateByIdQuery, UpdateProductByIdQueryResult>
    {
        private readonly Context context;

        public GetProductUpdateByIdQueryHandler(Context context)
        {
            this.context = context;
        }

        public async Task<UpdateProductByIdQueryResult> Handle(GetProductUpdateByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await context.Products.FindAsync(request.Id);
            return new UpdateProductByIdQueryResult
            {
                Category = values.Category,
                Name = values.Name,
                Price = values.Price,
                Stock = values.Stock,
                Type = values.Type
            };
        }
    }
}