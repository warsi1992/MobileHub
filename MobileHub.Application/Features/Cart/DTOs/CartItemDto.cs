using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.DTOs
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total => Price * Quantity;
    }
}
