using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.DeleteCart
{
    public class DeleteCartCommand : IRequest
    {
        public int CartItemId { get; set; }
    }
}
