using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
