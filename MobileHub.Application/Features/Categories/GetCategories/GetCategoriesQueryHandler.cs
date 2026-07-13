using MediatR;
using MobileHub.Application.Features.Categories.Dtos;
using MobileHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MobileHub.Application.Features.Categories.GetCategories
{
    public class GetCategoriesQueryHandler
    : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(
            GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    IsActive = c.IsActive,
                    ProductCount = c.Products.Count()
                })
                .ToListAsync<CategoryDto>(cancellationToken);
        }
    }
}
