using MediatR;
using MobileHub.Application.Features.Orders.DTOs;
using MobileHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders
     .Include(x => x.OrderItems)
         .ThenInclude(x => x.Product)
             .ThenInclude(x => x.Images)
     .Where(x => x.UserId == request.UserId)
     .OrderByDescending(x => x.OrderDate)
     .Select(x => new OrderDto
     {
         OrderId = x.Id,
         OrderDate = x.OrderDate,
         TotalAmount = x.TotalAmount,
         Status = x.Status,

         Items = x.OrderItems.Select(i => new OrderItemDto
         {
             ProductId = i.ProductId,
             ProductName = i.Product.Name,
             Quantity = i.Quantity,
             UnitPrice = i.UnitPrice,

             ImageUrl = i.Product.Images
                 .OrderBy(p => p.DisplayOrder)
                 .Select(p => p.ImageUrl)
                 .FirstOrDefault()

         }).ToList()
     })
     .ToListAsync(cancellationToken);
        }
    }
}
