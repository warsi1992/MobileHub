using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);

            if (order == null)
                throw new Exception("Order not found.");

            order.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
