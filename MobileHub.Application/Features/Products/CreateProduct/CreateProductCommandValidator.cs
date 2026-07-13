using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.SKU)
                .NotEmpty();
        }
    }
}
