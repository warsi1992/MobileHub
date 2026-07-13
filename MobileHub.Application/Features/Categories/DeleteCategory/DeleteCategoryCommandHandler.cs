using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler
     : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (category == null)
                return false;

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
