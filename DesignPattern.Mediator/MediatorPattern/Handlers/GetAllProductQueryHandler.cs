using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatorPattern.Queries;
using DesignPattern.Mediator.MediatorPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.MediatorPattern.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryResult>>
    {
        private readonly Context context;

        public GetAllProductQueryHandler(Context context)
        {
            this.context = context;
        }

        public async Task<List<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var values = await context.Products.Select(x => new GetAllProductQueryResult
            {
                Id = x.Id,
                Category = x.Category,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Type = x.Type
            }).AsNoTracking().ToListAsync();

            return values;
        }
    }
}