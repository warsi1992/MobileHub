using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.GetProducts
{
    public class ProductFilter
    {
        public string? Search { get; set; }

        public int? CategoryId { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? SortBy { get; set; }

        public string? SortOrder { get; set; } = "asc";
    }
}
