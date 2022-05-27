using Domain.Repositories;
using System;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository SupplierRepository { get; }
        IProductItemRepository ProductItemRepository { get; }
        IProductSupplierRepository ProductSupplierRepository { get; }
        int Complete();
    }
}
