using MediatR;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                DiscountPrice = request.DiscountPrice,
                StockQuantity = request.StockQuantity,
                SKU = request.SKU,
                IsFeatured = request.IsFeatured,
                IsActive = request.IsActive,
                BrandName = request.BrandName,
                Color = request.Color,
                Compatibility = request.Compatibility,
                WarrantyMonths = request.WarrantyMonths,
                Weight = request.Weight,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
