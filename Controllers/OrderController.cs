using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Commands;
using OrderManagementAPI.Handlers.Queries;

namespace OrderManagementAPI.Controllers
{
    [ApiController]
    [Route("api/orders/")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <param name="command">Order creation details</param>
        /// <returns>Created order ID</returns>
        [HttpPost("/CreateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command) =>
            Ok(await _mediator.Send(command));

        /// <summary>
        /// Get order details by ID.
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <returns>Order details</returns>
        [HttpGet("/GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id) =>
            Ok(await _mediator.Send(new GetOrderByIdQuery { Id = id }));

        /// <summary>
        /// Update order status.
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <param name="command">New order status</param>
        /// <returns>True if updated successfully</returns>
        [HttpPut("/UpdateOrderStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] UpdateOrderStatusCommand command) =>
            Ok(await _mediator.Send(new UpdateOrderStatusCommand { Id = id, Status = command.Status }));
    }
}
