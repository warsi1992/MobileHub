using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileHub.Application.Common.Models;
using MobileHub.Application.Interfaces;
using MobileHub.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Auth.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(
            IApplicationDbContext context,
            IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (user == null)
                throw new Exception("Invalid email or password.");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid email or password.");

            return new LoginResponse
            {
                Token = _jwtService.GenerateToken(user),
                UserId = user.Id,
                FirstName = user.FirstName,
                Role = user.Role
            };
        }
    }
}
