using MediatR;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;

namespace OrderManagementAPI.Commands
{
    public class CreateOrderCommand : IRequest<string>
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Amount { get; set; }
    }
}
