using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public CancelOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);

            if (order == null)
                throw new Exception("Order not found.");

            if (order.Status == "Delivered")
                throw new Exception("Delivered orders cannot be cancelled.");

            order.Status = "Cancelled";

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
