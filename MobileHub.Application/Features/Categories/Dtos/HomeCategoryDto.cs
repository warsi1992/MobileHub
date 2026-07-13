using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.Dtos
{
    public class HomeCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public int ProductCount { get; set; }
    }
}
