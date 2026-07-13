using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Features.Cart.DTOs;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, List<CartItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCartQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItemDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _context.CartItems
                .Where(x => x.UserId == request.UserId)
                .Include(x => x.Product)
                .Select(x => new CartItemDto
                {
                    CartItemId = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity
                })
                .ToListAsync(cancellationToken);
        }
    }
}
