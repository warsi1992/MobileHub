using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.CreateCategory
{
    public class CreateCategoryCommandValidator
     : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(150);
        }
    }
}
