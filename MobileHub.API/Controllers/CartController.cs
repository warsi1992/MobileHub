using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Application.Features.Cart.AddToCart;
using MobileHub.Application.Features.Cart.ClearCart;
using MobileHub.Application.Features.Cart.DeleteCart;
using MobileHub.Application.Features.Cart.GetCart;
using MobileHub.Application.Features.Cart.UpdateCart;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(new
            {
                CartItemId = id,
                Message = "Item added to cart."
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var result = await _mediator.Send(new GetCartQuery
            {
                UserId = userId
            });

            return Ok(result);
        }

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new Exception("This is a test exception.");
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCartCommand command)
        {
            await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Cart updated successfully."
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCartCommand
            {
                CartItemId = id
            });

            return Ok("Item removed from cart.");
        }

        [HttpDelete("user/{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await _mediator.Send(new ClearCartCommand
            {
                UserId = userId
            });

            return Ok("Cart cleared successfully.");
        }
    }
}

