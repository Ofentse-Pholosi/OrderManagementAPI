using MediatR;
using MongoDB.Driver;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Commands
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public string Id { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
