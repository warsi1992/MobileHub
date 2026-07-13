using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Features.Categories.Dtos;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryHandler
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto?> Handle(
            GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Where(x => x.Id == request.Id)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
