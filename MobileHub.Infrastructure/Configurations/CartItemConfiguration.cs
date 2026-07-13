using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Infrastructure.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.ProductId);

            builder.Property(x => x.Quantity)
                   .IsRequired();
        }
    }
}
