using Microsoft.EntityFrameworkCore;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }

        DbSet<Category> Categories { get; }
        DbSet<ProductImage> ProductImages { get; }
        DbSet<User> Users { get; }
        DbSet<CartItem> CartItems { get; }
        DbSet<Order> Orders { get; }

        DbSet<OrderItem> OrderItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
