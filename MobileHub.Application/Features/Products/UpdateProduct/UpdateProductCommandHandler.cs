using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler
      : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product == null)
                return false;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.DiscountPrice = request.DiscountPrice;
            product.StockQuantity = request.StockQuantity;
            product.SKU = request.SKU;
            product.IsFeatured = request.IsFeatured;
            product.IsActive = request.IsActive;
            product.BrandName = request.BrandName;
            product.Color = request.Color;
            product.Compatibility = request.Compatibility;
            product.WarrantyMonths = request.WarrantyMonths;
            product.Weight = request.Weight;
            product.CategoryId = request.CategoryId;
            product.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
