using Domain.Enums;
using System;

namespace Models.DTO
{
    public class ProductItemUpdateView
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public EProductStatus ProductStatus { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public string CurrentSupplierId { get; set; }
        public SupplierView ObjNewSupplier { get; set; }
    }
}
