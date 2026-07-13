using MobileHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int StockQuantity { get; set; }

        public string SKU { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        // Relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Product Details
        public string? BrandName { get; set; }

        public string? Color { get; set; }

        public string? Compatibility { get; set; }
        // Example: "iPhone 15, iPhone 16"

        public int WarrantyMonths { get; set; }

        public decimal Weight { get; set; }

        // Navigation
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
