using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public int CartItemId { get; set; }

        public int Quantity { get; set; }
    }
}
