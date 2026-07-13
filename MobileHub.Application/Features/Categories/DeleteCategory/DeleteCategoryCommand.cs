using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool>;
}
