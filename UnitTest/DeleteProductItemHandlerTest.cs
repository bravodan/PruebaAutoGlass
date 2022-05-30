using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest.Config;
using Services.EventHandlers;
using Services.Commands;
using System.Threading;
using Domain.Entities;
using Domain.Enums;

namespace UnitTest
{
    [TestClass]
    public class DeleteProductItemHandlerTest
    {
        [TestMethod]
        public void TryUpdateProductItemWithManufacturingGreatherThanValidity()
        {
            var Context = UnitTestDbContext.Get();
            UnitOfWork objUnitOfWork = new UnitOfWork(Context);

            var handler = new DeleteProductItemHandler(objUnitOfWork);

            Supplier objSupplierAdded = Context.Suppliers.Add(new Supplier("2", "Proveedor de arequipe", "3133333333")).Entity;
            Context.SaveChanges();

            ProductItem objProductAdded = Context.Products.Add(new ProductItem("description", null, null, objSupplierAdded)).Entity;
            Context.SaveChanges();

            handler.Handle(
                new DeleteProductItemCommand(objProductAdded.Id),
                new CancellationToken()).Wait();

            EProductStatus varProductstatus = Context.Products.Find(objProductAdded.Id).ProductStatus;
            Assert.AreEqual(EProductStatus.inactivo, varProductstatus);

        }
    }
}
