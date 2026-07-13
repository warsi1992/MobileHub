using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(x => x.Id == request.CartItemId, cancellationToken);

            if (item == null)
                throw new Exception("Cart item not found.");

            _context.CartItems.Remove(item);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
