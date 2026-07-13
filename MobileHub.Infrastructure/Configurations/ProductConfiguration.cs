using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SKU)
                   .HasMaxLength(100);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.DiscountPrice)
       .HasColumnType("decimal(18,2)");
            builder.Property(x => x.BrandName)
       .HasMaxLength(100);

            builder.Property(x => x.Color)
                   .HasMaxLength(50);

            builder.Property(x => x.Compatibility)
                   .HasMaxLength(500);

            builder.Property(x => x.Weight)
                   .HasColumnType("decimal(10,2)");

            builder.Property(x => x.WarrantyMonths)
                   .HasDefaultValue(0);

            

        }
    }
}
