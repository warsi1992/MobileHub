using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Common.Models;
using MobileHub.Application.Features.Products.DTOs;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.GetProducts
{
    public class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, PagedResponse<ProductDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Products
    .Include(x => x.Category)
    .Include(x => x.Images)
    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Filter.Search))
            {
                query = query.Where(x =>
                    x.Name.Contains(request.Filter.Search));
            }

            if (request.Filter.CategoryId.HasValue)
            {
                query = query.Where(x =>
                    x.CategoryId == request.Filter.CategoryId);
            }

            switch (request.Filter.SortBy?.ToLower())
            {
                case "price":
                    query = request.Filter.SortOrder == "desc"
                        ? query.OrderByDescending(x => x.Price)
                        : query.OrderBy(x => x.Price);
                    break;

                case "name":
                    query = request.Filter.SortOrder == "desc"
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                    break;

                case "stock":
                    query = request.Filter.SortOrder == "desc"
                        ? query.OrderByDescending(x => x.StockQuantity)
                        : query.OrderBy(x => x.StockQuantity);
                    break;

                case "newest":
                    query = request.Filter.SortOrder == "desc"
                        ? query.OrderBy(x => x.CreatedOn)
                        : query.OrderByDescending(x => x.CreatedOn);
                    break;

                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            var totalCount = await query.CountAsync(cancellationToken);
            query = query
                .Skip((request.Filter.Page - 1) * request.Filter.PageSize)
                .Take(request.Filter.PageSize);

            var products = await query
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    DiscountPrice = x.DiscountPrice,
                    StockQuantity = x.StockQuantity,
                    SKU = x.SKU,
                    CategoryId = x.CategoryId,
                    BrandName = x.BrandName,
                    Color = x.Color,
                    ImageUrl = x.Images
    .OrderBy(i => i.DisplayOrder)
    .Select(i => i.ImageUrl)
    .FirstOrDefault(),
                    Compatibility = x.Compatibility,
                    WarrantyMonths = x.WarrantyMonths,
                    Weight = x.Weight,
                    IsFeatured = x.IsFeatured,
                    CategoryName = x.Category.Name,
                    IsActive = x.IsActive
                })
                .ToListAsync(cancellationToken);

            return new PagedResponse<ProductDto>
            {
                Items = products,
                Page = request.Filter.Page,
                PageSize = request.Filter.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.Filter.PageSize)
            };
        }
    }
}
