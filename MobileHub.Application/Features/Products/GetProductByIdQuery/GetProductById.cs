using MediatR;
using MobileHub.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.GetProductByIdQuery
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;
}
