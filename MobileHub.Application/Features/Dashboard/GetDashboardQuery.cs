using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Dashboard
{
    public class GetDashboardQuery : IRequest<DashboardDto>
    {
    }
}
