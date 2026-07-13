using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Application.Features.Categories.CreateCategory;
using MobileHub.Application.Features.Categories.DeleteCategory;
using MobileHub.Application.Features.Categories.GetCategories;
using MobileHub.Application.Features.Categories.GetCategoryById;
using MobileHub.Application.Features.Categories.GetHomeCategoriesQuery;
using MobileHub.Application.Features.Categories.UpdateCategory;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            

            var updated = await _mediator.Send(command);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpPut("Updatecat/{id:int}")]
        public async Task<IActionResult> Updatecat(int id, UpdateCategoryCommand command)
        {
            command.Id= id;

            var updated = await _mediator.Send(command);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteCategoryCommand(id));

            if (!deleted)
                return NotFound();

            return NoContent();
        }


        [HttpGet("home")]
        public async Task<IActionResult> GetHomeCategories()
        {
            return Ok(await _mediator.Send(new GetHomeCategoriesQuery()));
        }
    }
}
