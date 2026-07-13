using MediatR;
using MobileHub.Application.Features.Cart.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Cart.GetCart
{
    public class GetCartQuery : IRequest<List<CartItemDto>>
    {
        public int UserId { get; set; }
    }
}
