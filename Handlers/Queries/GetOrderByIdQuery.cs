using MediatR;
using MongoDB.Driver;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Handlers.Queries
{
    public class GetOrderByIdQuery : IRequest<Order?>
    {
        public string? Id { get; set; }

    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?>
    {
        private readonly MongoDBContext _context;

        public GetOrderByIdHandler(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders
                .Find(o => o.OrderId == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
