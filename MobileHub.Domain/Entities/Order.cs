using MobileHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";

        // Shipping Information
        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Pincode { get; set; } = string.Empty;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
