using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (category == null)
                return false;

            category.Name = request.Name;
            category.Description = request.Description;
            category.ImageUrl = request.ImageUrl;
            category.IsActive = request.IsActive;

            category.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
