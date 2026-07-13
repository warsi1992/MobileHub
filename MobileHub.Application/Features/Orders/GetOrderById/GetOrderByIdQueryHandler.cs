using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Features.Orders.DTOs;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetailDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
               .Include(x => x.OrderItems)
    .ThenInclude(x => x.Product)
        .ThenInclude(x => x.Images)

                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);

            if (order == null)
                return null;

            return new OrderDetailDto
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,

                FullName = order.FullName,
                Phone = order.Phone,
                Address = order.Address,
                City = order.City,
                State = order.State,
                Pincode = order.Pincode,

                Items = order.OrderItems.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,

                    ImageUrl = i.Product.Images
        .OrderBy(p => p.DisplayOrder)
        .Select(p => p.ImageUrl)
        .FirstOrDefault()

                }).ToList()
            };
        }
    }
}
