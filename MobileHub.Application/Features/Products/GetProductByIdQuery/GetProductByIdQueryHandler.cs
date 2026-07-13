using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Features.Products.DTOs;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.GetProductByIdQuery
{
    public class GetProductByIdQueryHandler
     : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(x => x.Category)
                .Where(x => x.Id == request.Id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    StockQuantity = x.StockQuantity,
                    SKU = x.SKU,
                    IsFeatured = x.IsFeatured,
                    IsActive = x.IsActive,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    ImageUrl = x.Images
            .OrderBy(i => i.DisplayOrder)
            .Select(i => i.ImageUrl)
            .FirstOrDefault(),

                    Images = x.Images
            .OrderBy(i => i.DisplayOrder)
            .Select(i => new ProductImageDto
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl
            })
            .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
