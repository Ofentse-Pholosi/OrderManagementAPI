using MediatR;
using MongoDB.Driver;
using OrderManagementAPI.Commands;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly MongoDBContext _context;

        public CreateOrderCommandHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                Amount = request.Amount,
                Status = "Pending"
            };

            await _context.Orders.InsertOneAsync(order, cancellationToken: cancellationToken);
            return order.OrderId;
        }
    }
}
