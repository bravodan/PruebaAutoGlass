using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<ProductSupplier> ProductsSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
