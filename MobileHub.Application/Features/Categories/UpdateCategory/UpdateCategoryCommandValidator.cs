using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.UpdateCategory
{
    public class UpdateCategoryCommandValidator
    : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
