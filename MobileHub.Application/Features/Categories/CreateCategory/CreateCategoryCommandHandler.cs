using MediatR;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                IsActive = request.IsActive
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
