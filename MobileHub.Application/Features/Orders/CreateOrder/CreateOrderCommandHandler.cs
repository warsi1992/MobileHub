using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cartItems = await _context.CartItems
                .Where(x => x.UserId == request.UserId)
                .Include(x => x.Product)
                .ToListAsync(cancellationToken);

            if (!cartItems.Any())
                throw new Exception("Cart is empty.");

            var order = new Order
            {
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow,

                FullName = request.FullName,
                Phone = request.Phone,
                Address = request.Address,
                City = request.City,
                State = request.State,
                Pincode = request.Pincode,

                Status = "Pending",
                TotalAmount = cartItems.Sum(x => x.Product.Price * x.Quantity)
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync(cancellationToken);

            foreach (var item in cartItems)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price
                });
            }

            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
