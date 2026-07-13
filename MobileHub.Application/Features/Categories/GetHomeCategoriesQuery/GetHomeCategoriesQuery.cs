using MediatR;
using MobileHub.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.GetHomeCategoriesQuery
{
    public class GetHomeCategoriesQuery : IRequest<List<HomeCategoryDto>>
    {
    }
}
