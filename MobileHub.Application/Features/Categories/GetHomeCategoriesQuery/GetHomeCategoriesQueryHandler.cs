using MediatR;
using MobileHub.Application.Features.Categories.Dtos;
using MobileHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.GetHomeCategoriesQuery
{
    public class GetHomeCategoriesQueryHandler
        : IRequestHandler<GetHomeCategoriesQuery, List<HomeCategoryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetHomeCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HomeCategoryDto>> Handle(
            GetHomeCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Select(x => new HomeCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,

                    // Add this when category image upload is implemented
                    ImageUrl = null,

                    ProductCount = x.Products.Count()
                })
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
