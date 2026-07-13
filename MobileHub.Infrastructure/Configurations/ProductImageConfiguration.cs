using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Infrastructure.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                   .HasMaxLength(255);

            builder.Property(x => x.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.IsPrimary)
                   .HasDefaultValue(false);

            builder.Property(x => x.DisplayOrder)
                   .HasDefaultValue(1);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
