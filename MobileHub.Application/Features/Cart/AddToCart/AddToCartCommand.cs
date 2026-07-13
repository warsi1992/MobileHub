using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.AddToCart
{
    public class AddToCartCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
