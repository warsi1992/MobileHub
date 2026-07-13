using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int StockQuantity { get; set; }

        public string SKU { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
    }
}
