using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.AddToCart
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddToCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);

            if (product == null)
                throw new Exception("Product not found.");

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(x =>
                    x.UserId == request.UserId &&
                    x.ProductId == request.ProductId,
                    cancellationToken);

            if (cartItem != null)
            {
                cartItem.Quantity += request.Quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return cartItem.Id;
        }
    }
}
