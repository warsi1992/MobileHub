using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Total => UnitPrice * Quantity;
    }
}
