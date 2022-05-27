using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductItemRepository : IGenericRepository<ProductItem>
    {
        ProductItem GetById(long id);
    }
}
