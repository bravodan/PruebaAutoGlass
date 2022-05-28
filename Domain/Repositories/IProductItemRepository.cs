using Domain.Entities;
using Domain.Pagination;
using Domain.QueryParams;

namespace Domain.Repositories
{
    public interface IProductItemRepository : IGenericRepository<ProductItem>
    {
        ProductItem GetById(long id);
        PagedList<ProductItem> GetProductItems(ProductItemParameters parameters);
    }
}
