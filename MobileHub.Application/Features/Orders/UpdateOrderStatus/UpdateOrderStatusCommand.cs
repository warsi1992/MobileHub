using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
