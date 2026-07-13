using MobileHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}
