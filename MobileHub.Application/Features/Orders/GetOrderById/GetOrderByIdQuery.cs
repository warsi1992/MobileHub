using MediatR;
using MobileHub.Application.Features.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDetailDto?>
    {
        public int OrderId { get; set; }
    }
}
