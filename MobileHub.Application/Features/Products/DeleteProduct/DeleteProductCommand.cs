using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
