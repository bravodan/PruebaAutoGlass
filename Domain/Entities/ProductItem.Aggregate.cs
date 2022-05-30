using Domain.Enums;
using System;

namespace Domain.Entities
{
    public partial class ProductItem
    {

        public ProductItem(string description, DateTime? manufacturingDate, DateTime? validityDate, Supplier supplier)
        {
            if (manufacturingDate > validityDate)
            {
                throw new Exception("La fecha de fabricación debe ser menor a la de validez");
            }
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
