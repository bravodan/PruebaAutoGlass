using Domain.Entities;
using Domain.Repositories;
using Persistence.Database;

namespace DataAccess.Repositories
{
    public class ProductSupplierRepository : GenericRepository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
