using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.ClearCart
{
    public class ClearCartCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
