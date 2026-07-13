using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Application.Features.Orders.CancelOrder;
using MobileHub.Application.Features.Orders.CreateOrder;
using MobileHub.Application.Features.Orders.GetOrderById;
using MobileHub.Application.Features.Orders.GetOrders;
using MobileHub.Application.Features.Orders.UpdateOrderStatus;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);

            return Ok(new
            {
                OrderId = orderId,
                Message = "Order placed successfully."
            });
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var result = await _mediator.Send(new GetOrdersQuery
            {
                UserId = userId
            });

            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery
            {
                OrderId = id
            });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("status")]
        // Later change to [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateStatus(UpdateOrderStatusCommand command)
        {
            await _mediator.Send(command);

            return Ok("Order status updated.");
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _mediator.Send(new CancelOrderCommand
            {
                OrderId = id
            });

            return Ok("Order cancelled successfully.");
        }
    }
}
