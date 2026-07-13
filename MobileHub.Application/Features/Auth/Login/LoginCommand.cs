using MediatR;
using MobileHub.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";
    }
}
