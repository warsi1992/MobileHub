using MediatR;
using MobileHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Dashboard
{
    public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, DashboardDto>
    {
        private readonly IApplicationDbContext _context;

        public GetDashboardQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            return new DashboardDto
            {
                TotalUsers = await _context.Users.CountAsync(cancellationToken),

                TotalProducts = await _context.Products.CountAsync(cancellationToken),

                TotalOrders = await _context.Orders.CountAsync(cancellationToken),

                TotalRevenue = await _context.Orders.SumAsync(x => x.TotalAmount, cancellationToken),

                PendingOrders = await _context.Orders.CountAsync(x => x.Status == "Pending", cancellationToken),

                CompletedOrders = await _context.Orders.CountAsync(x => x.Status == "Delivered", cancellationToken)
            };
        }
    }
}
