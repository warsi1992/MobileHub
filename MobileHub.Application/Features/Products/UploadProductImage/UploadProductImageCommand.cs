using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.UploadProductImage
{
    public class UploadProductImageCommand : IRequest<string>
    {
        public int ProductId { get; set; }

        public IFormFile File { get; set; } = null!;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; } = 1;
    }
}
