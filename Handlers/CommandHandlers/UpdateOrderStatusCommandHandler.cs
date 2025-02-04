using MediatR;
using MongoDB.Driver;
using OrderManagementAPI.Commands;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Handlers.CommandHandlers
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly MongoDBContext _context;

        public UpdateOrderStatusCommandHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var update = Builders<Order>.Update.Set(o => o.Status, request.Status);
            var result = await _context.Orders.UpdateOneAsync(o => o.OrderId == request.Id, update, cancellationToken: cancellationToken);
            return result.ModifiedCount > 0;
        }
    }
}
