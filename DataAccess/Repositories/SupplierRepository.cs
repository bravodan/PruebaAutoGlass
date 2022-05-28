using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Linq;

namespace DataAccess.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context):base(context)
        {

        }

        public Supplier GetById(string id)
        {
            return _context.Suppliers.AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }
    }
}
