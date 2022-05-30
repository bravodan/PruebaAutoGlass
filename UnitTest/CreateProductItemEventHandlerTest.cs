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
    public class CreateProductItemEventHandlerTest
    {
        [TestMethod]
        public void TryToCreateWithAllParameters()
        {
            var Context = UnitTestDbContext.Get();
            var Automapper = AutoMapperTestIntance.Get();
            UnitOfWork objUnitOfWork = new UnitOfWork(Context);

            var handler = new AddProductItemHandler(objUnitOfWork, Automapper);

            Context.Suppliers.Add(new Supplier("123", "Proveedor de arequipe", "3133333333"));
            Context.SaveChanges();

            ProductItemCreateView objObjectToCreate = new ProductItemCreateView
            {
                Description = "arequipe",
                ManufacturingDate = DateTime.Now,
                ValidityDate = DateTime.Now,
                SupplierId = "123"
            };

            ProductItemCreateResponse objProductAdded = handler.Handle(
                new AddProductItemCommand(objObjectToCreate),
                new CancellationToken()).Result;

            Assert.AreEqual(objProductAdded.Description, objObjectToCreate.Description);
            Assert.AreEqual(objProductAdded.ManufacturingDate, objObjectToCreate.ManufacturingDate);
            Assert.AreEqual(objProductAdded.ValidityDate, objObjectToCreate.ValidityDate);
            Assert.AreEqual(objProductAdded.SupplierId, objObjectToCreate.SupplierId);
            Assert.AreEqual(objProductAdded.ProductStatus, EProductStatus.activo);

        }

        [TestMethod]
        [ExpectedException(typeof(AddProductItemCommandException))]
        public void TryToCreateWithManufacturingGreatherThanValidity()
        {
            var Context = UnitTestDbContext.Get();
            var Automapper = AutoMapperTestIntance.Get();
            UnitOfWork objUnitOfWork = new UnitOfWork(Context);

            var handler = new AddProductItemHandler(objUnitOfWork, Automapper);

            Context.Suppliers.Add(new Supplier("1234", "Proveedor de arequipe", "3133333333"));
            Context.SaveChanges();

            DateTime currentDate = DateTime.Now;

            ProductItemCreateView objObjectToCreate = new ProductItemCreateView
            {
                Description = "arequipe",
                ManufacturingDate = currentDate,
                ValidityDate = currentDate,
                SupplierId = "1234"
            };

            try
            {
                ProductItemCreateResponse objProductAdded = handler.Handle(
                    new AddProductItemCommand(objObjectToCreate),
                    new CancellationToken()).Result;
            }
            catch(AggregateException e)
            {
                var exception = e.GetBaseException();

                if(exception is AddProductItemCommandException)
                {
                    throw new AddProductItemCommandException(exception?.InnerException?.Message);
                }
            }
        }
    }
}
