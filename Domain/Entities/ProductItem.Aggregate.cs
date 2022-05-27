using Domain.Enums;
using System;

namespace Domain.Entities
{
    public partial class ProductItem
    {

        public ProductItem(long id, string description, DateTime? manufacturingDate, DateTime? validityDate)
        {
            Id = id;
            Description = description;
            ProductStatus = EProductStatus.inactivo;
            ManufacturingDate = manufacturingDate;
            ValidityDate = validityDate;
        }

        public ProductItem()
        {
        }

        public void Update(string description, EProductStatus productState, DateTime? manufacturingDate, DateTime? validityDate)
        {
            if (manufacturingDate >= validityDate)
            {
                throw new Exception("La fecha de fabricación debe ser menor a la de vencimiento");
            }
            Description = description;
            ProductStatus = productState;
            ManufacturingDate = manufacturingDate;
            ValidityDate = validityDate;
        }

        public void Update(string description, EProductStatus productState, DateTime? manufacturingDate, DateTime? validityDate, string oldSupplierId, Supplier objNewSupplier)
        {
            Update(description, productState, manufacturingDate, validityDate);
            UpdateProductSupplierList(oldSupplierId, objNewSupplier);
        }


        public void UpdateProductSupplierList(string oldSupplierId, Supplier newSupplier)
        {
            ProductSupplier objProductSupplierToAdd = new ProductSupplier(Id, newSupplier.id, DateTime.Now, null);
            if (oldSupplierId != null)
            {
                foreach (var objProductSupplier in ProductSupplierList)
                {
                    if (objProductSupplier.SuppId == oldSupplierId)
                    {
                        objProductSupplier.Update(objProductSupplier.ProdId, objProductSupplier.SuppId, objProductSupplier.StartDate, DateTime.Now);
                    }
                }
            }
            ProductSupplierList.Add(objProductSupplierToAdd);
        }

        public string getCurrentSupplierId()
        {
            return ProductSupplierList.Find(x=>x.EndDate==null).SuppId;
        }

        public void ActiveProductState()
        {
            ProductStatus = EProductStatus.activo;
        }

        public void DeactiveProductState()
        {
            ProductStatus = EProductStatus.inactivo;
        }

    }
}
