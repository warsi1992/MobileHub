using MediatR;
using MobileHub.Application.Interfaces;
using MobileHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Auth.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public RegisterUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var exists = await _context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);

            if (exists)
                throw new Exception("Email already exists.");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

                // Temporary - we'll hash it next
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),

                PhoneNumber = request.PhoneNumber,

                Role = "Customer",

                IsActive = true
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
