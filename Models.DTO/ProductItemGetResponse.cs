
using Domain.Enums;
using System;

namespace Models.DTO
{
    public class ProductItemGetResponse
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public EProductStatus ProductStatus { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public SupplierView Supplier { get; set; }

        public ProductItemGetResponse()
        {
        }
    }
}
