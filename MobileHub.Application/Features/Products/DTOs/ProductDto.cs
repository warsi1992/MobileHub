using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int StockQuantity { get; set; }

        public string SKU { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? BrandName { get; set; }

        public string? Color { get; set; }

        public string? Compatibility { get; set; }

        public int WarrantyMonths { get; set; }

        public decimal Weight { get; set; }
        public List<ProductImageDto> Images { get; set; } = new();
    }
}
