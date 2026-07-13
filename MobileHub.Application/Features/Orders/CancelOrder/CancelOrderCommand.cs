using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        public int OrderId { get; set; }
    }
}
