using DataAccess.Repositories;
using Domain.Repositories;
using Domain.UnitOfWork;
using Persistence.Database;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            SupplierRepository = new SupplierRepository(_context);
            ProductItemRepository = new ProductItemRepository(_context);
        }

        public ISupplierRepository SupplierRepository { get; private set; }

        public IProductItemRepository ProductItemRepository { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
