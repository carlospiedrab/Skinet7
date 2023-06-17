using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.Price).IsRequired();
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.Property(p=>p.ProductTypeId).IsRequired();
            builder.Property(p=>p.ProductBrandId).IsRequired();

            builder.HasOne(b=>b.ProductBrand)
              .WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(b=>b.ProductType)
              .WithMany().HasForeignKey(p=>p.ProductTypeId);                  
        }
    }
}