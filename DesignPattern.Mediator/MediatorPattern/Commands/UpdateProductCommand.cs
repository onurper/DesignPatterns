using MediatR;

namespace DesignPattern.Mediator.MediatorPattern.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}