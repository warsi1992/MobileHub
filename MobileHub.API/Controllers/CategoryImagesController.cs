using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Infrastructure.Persistence;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CategoryImagesController(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Upload(
            int categoryId,
            IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var category = await _context.Categories.FindAsync(categoryId);

            if (category == null)
                return NotFound("Category not found.");

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "categories");

            Directory.CreateDirectory(uploadFolder);

            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            category.ImageUrl = "/uploads/categories/" + fileName;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                category.Id,
                category.ImageUrl
            });
        }
    }
}
