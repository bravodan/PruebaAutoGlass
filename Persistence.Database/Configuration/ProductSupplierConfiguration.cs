using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Configuration
{
    class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.HasKey(ps => new { ps.ProdId, ps.SuppId, ps.StartDate });

            builder.Property(ps => ps.EndDate).IsRequired(false);

            builder.HasOne(ps => ps.ProductItem)
                .WithMany(p => p.ProductSupplierList)
                .HasForeignKey(pt => pt.ProdId);

            builder.HasOne(pt => pt.Supplier)
                .WithMany(t => t.ProductSupplierList)
                .HasForeignKey(pt => pt.SuppId);
        }
    }
}
