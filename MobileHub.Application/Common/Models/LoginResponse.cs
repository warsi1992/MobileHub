using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Common.Models
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;

        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
