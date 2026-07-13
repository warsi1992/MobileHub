using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Features.Dashboard
{
    public class DashboardDto
    {
        public int TotalUsers { get; set; }

        public int TotalProducts { get; set; }

        public int TotalOrders { get; set; }

        public decimal TotalRevenue { get; set; }

        public int PendingOrders { get; set; }

        public int CompletedOrders { get; set; }
    }
}
