using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.DTOs
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Pincode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        
        
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
