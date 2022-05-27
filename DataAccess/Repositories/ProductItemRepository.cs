using Domain.Entities;
using Domain.Repositories;
using Persistence.Database;

namespace DataAccess.Repositories
{
    public class ProductItemRepository : GenericRepository<ProductItem>, IProductItemRepository
    {
        public ProductItemRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ProductItem GetById(long id)
        {
            return _context.Products.Find(id);
        }
    }
}
