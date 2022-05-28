using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Database.Configuration
{
    class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).IsRequired(true);
            builder.HasMany(p => p.ProductItemList).WithOne(s => s.Supplier).HasForeignKey(p => p.SuppId).OnDelete(DeleteBehavior.SetNull);
            builder.Navigation(p => p.ProductItemList).UsePropertyAccessMode(PropertyAccessMode.Property);

        }
    }
}
