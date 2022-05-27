using Domain.Entities;
using Domain.Repositories;
using Persistence.Database;

namespace API.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
