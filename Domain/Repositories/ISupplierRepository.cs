using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Supplier GetById(string id);
    }
}
