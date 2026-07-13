using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Infrastructure.Contract
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
