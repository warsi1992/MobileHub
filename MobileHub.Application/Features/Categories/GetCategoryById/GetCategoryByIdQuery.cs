using MediatR;
using MobileHub.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.GetCategoryById
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto?>;
}
