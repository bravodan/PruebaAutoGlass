using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ProductItem
    {
        public long Id { get; protected set; }
        public string Description { get; protected set; }
        public EProductStatus ProductStatus { get; protected set; }
        public DateTime? ManufacturingDate { get; protected set; }
        public DateTime? ValidityDate { get; protected set; }
        public List<ProductSupplier> ProductSupplierList { get; set; }


    }
}
