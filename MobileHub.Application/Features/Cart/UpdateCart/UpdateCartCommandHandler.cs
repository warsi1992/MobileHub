using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.UpdateCart
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(x => x.Id == request.CartItemId, cancellationToken);

            if (item == null)
                throw new Exception("Cart item not found.");

            item.Quantity = request.Quantity;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
