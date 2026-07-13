using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Application.Features.Products.CreateProduct;
using MobileHub.Application.Features.Products.DeleteProduct;
using MobileHub.Application.Features.Products.GetProductByIdQuery;
using MobileHub.Application.Features.Products.GetProducts;
using MobileHub.Application.Features.Products.UpdateProduct;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
        [AllowAnonymous]
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
        {
            var result = await _mediator.Send(new GetProductsQuery());

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product is null)
                return NotFound();

            return Ok(product);
        }
        [Authorize(Roles = "Admin")]

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var updated = await _mediator.Send(command);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteProductCommand(id));

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _mediator.Send(new GetProductsQuery
            {
                Filter = new ProductFilter
                {
                    CategoryId = categoryId
                }
            });

            return Ok(result);
        }
    }

}
