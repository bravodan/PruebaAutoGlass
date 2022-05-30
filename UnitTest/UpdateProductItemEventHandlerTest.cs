using DataAccess;
using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.DTO;
using Services.Commands;
using Services.EventHandlers;
using Services.Exceptions.EventHanders;
using System;
using System.Threading;
using UnitTest.Config;

namespace UnitTest
{
    [TestClass]
    public class UpdateProductItemEventHandlerTest
    {
        [TestMethod]
        [ExpectedException(typeof(UpdateProductItemCommandException))]
        public void TryUpdateProductItemWithManufacturingGreatherThanValidity()
        {
            var Context = UnitTestDbContext.Get();
            UnitOfWork objUnitOfWork = new UnitOfWork(Context);

            Supplier objSupplierAdded = Context.Suppliers.Add(new Supplier("12345", "Proveedor de arequipe", "3133333333")).Entity;
            ProductItem objOldProductAdded = Context.Products.Add(new ProductItem("producto para update", null, null, objSupplierAdded)).Entity;
            Context.SaveChanges();

            var handler = new UpdateProductItemHandler(objUnitOfWork);

            ProductItemUpdateView objUpdateRequest = new ProductItemUpdateView
            {
                Id = objOldProductAdded.Id,
                Description = "new description",
                ProductStatus = EProductStatus.activo,
                ManufacturingDate = DateTime.Now.AddDays(1),
                SupplierId = objSupplierAdded.Id,
                ValidityDate = DateTime.Now
            };

            try
            {
                handler.Handle(
                    new UpdateProductItemCommand(objUpdateRequest),
                    new CancellationToken()).Wait();
            }
            catch (AggregateException e)
            {
                var exception = e.GetBaseException();

                if (exception is UpdateProductItemCommandException)
                {
                    throw new UpdateProductItemCommandException(exception?.InnerException?.Message);
                }
            }

        }

    }
}
