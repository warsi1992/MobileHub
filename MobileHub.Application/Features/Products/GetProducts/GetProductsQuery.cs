using MediatR;
using MobileHub.Application.Common.Models;
using MobileHub.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.GetProducts
{
    public class GetProductsQuery : IRequest<PagedResponse<ProductDto>>
    {
        public ProductFilter Filter { get; set; } = new();
    }
}
