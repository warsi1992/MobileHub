using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.DeleteProduct
{
    public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product == null)
                return false;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
