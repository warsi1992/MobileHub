using MediatR;
using MobileHub.Application.Features.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public int UserId { get; set; }
    }
}
