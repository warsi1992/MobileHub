using MobileHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
