using Domain.Entities;
using Domain.Repositories;
using Persistence.Database;

namespace DataAccess.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context):base(context)
        {

        }

        public Supplier GetById(string id)
        {
            return _context.Suppliers.Find(id);
        }
    }
}
