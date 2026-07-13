using MediatR;
using MobileHub.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.GetCategories
{
    public record GetCategoriesQuery() : IRequest<List<CategoryDto>>;
}
