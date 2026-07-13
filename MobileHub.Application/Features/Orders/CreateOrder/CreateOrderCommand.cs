using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pincode { get; set; }
    }
}
