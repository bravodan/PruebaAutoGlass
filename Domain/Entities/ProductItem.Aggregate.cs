using Domain.Enums;
using System;

namespace Domain.Entities
{
    public partial class ProductItem
    {

        public ProductItem(string description, DateTime? manufacturingDate, DateTime? validityDate, Supplier supplier)
        {
            Description = description;
            ProductStatus = EProductStatus.inactivo;
            ManufacturingDate = manufacturingDate;
            ValidityDate = validityDate;
            SuppId = supplier.Id;
            Supplier = Supplier;
        }

        public ProductItem()
        {
        }

        public void Update(string description, EProductStatus productStatus, DateTime? manufacturingDate, DateTime? validityDate, Supplier supplier)
        {
            if (manufacturingDate != null && validityDate != null)
            {
                if (manufacturingDate >= validityDate)
                {
                    throw new Exception("La fecha de fabricación debe ser menor a la de vencimiento");
                }
            }
            ManufacturingDate = manufacturingDate;
            ValidityDate = validityDate;
            ProductStatus = productStatus;
            Description = description;
            SuppId = supplier.Id;
            Supplier = supplier;
        }

        public Supplier getSupplier()
        {
            return Supplier;
        }

        /*public void Update(string description, EProductStatus productState, DateTime? manufacturingDate, DateTime? validityDate, string oldSupplierId, string newSupplierId)
        {
            Update(description, productState, manufacturingDate, validityDate);
            UpdateProductSupplierList(oldSupplierId, newSupplierId);
        }


        public void UpdateProductSupplierList(string oldSupplierId, string newSupplierId)
        {
            if (oldSupplierId != null)
            {
                if (ProductSupplierList != null)
                {
                    foreach (var objProductSupplier in ProductSupplierList)
                    {
                        if (objProductSupplier.SuppId == oldSupplierId)
                        {
                            objProductSupplier.Update(DateTime.Now);
                        }
                    }
                }
            }
            ProductSupplier objProductSupplierToAdd = new ProductSupplier(Id, newSupplierId, DateTime.Now, null);
            ProductSupplierList.Add(objProductSupplierToAdd);
        }*/

        public string getCurrentSupplierId()
        {
            return Supplier.Id;
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
