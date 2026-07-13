using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status)
                   .HasMaxLength(50);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
