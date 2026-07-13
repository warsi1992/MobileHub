using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandValidator
     : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);
        }
    }
}
