using MobileHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }

        public Product Product { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
    }
}
