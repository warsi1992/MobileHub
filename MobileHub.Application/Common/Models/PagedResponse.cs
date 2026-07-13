using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Common.Models
{
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; } = new();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage => Page < TotalPages;

        public bool HasPreviousPage => Page > 1;
    }
}
