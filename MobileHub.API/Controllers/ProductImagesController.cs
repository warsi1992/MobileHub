using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileHub.Domain.Entities;
using MobileHub.Infrastructure.Persistence;

namespace MobileHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductImagesController(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> Upload(
            int productId,
            IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                return NotFound("Product not found.");

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "products");

            Directory.CreateDirectory(uploadFolder);

            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new ProductImage
            {
                ProductId = productId,
                FileName = fileName,
                ImageUrl = "/uploads/products/" + fileName,
                IsPrimary = false,
                DisplayOrder = 1
            };

            _context.ProductImages.Add(image);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                image.Id,
                image.ProductId,
                image.FileName,
                image.ImageUrl,
                image.IsPrimary,
                image.DisplayOrder
            });
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var images = await _context.ProductImages
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new
                {
                    x.Id,
                    x.ImageUrl,
                    x.IsPrimary,
                    x.DisplayOrder
                })
                .ToListAsync();

            return Ok(images);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _context.ProductImages.FindAsync(id);

            if (image == null)
                return NotFound();

            var filePath = Path.Combine(
                _environment.WebRootPath,
                image.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            _context.ProductImages.Remove(image);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
