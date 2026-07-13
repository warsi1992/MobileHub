using MediatR;
using MobileHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.ClearCart
{

    public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand>
    {
        private readonly IApplicationDbContext _context;

        public ClearCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            var items = await _context.CartItems
                .Where(x => x.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            _context.CartItems.RemoveRange(items);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
