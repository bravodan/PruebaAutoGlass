using Domain.Enums;
using System;

namespace Domain.Entities
{
    public partial class ProductItem
    {
        public long Id { get; protected set; }
        public string Description { get; protected set; }
        public EProductStatus ProductStatus { get; protected set; }
        public DateTime? ManufacturingDate { get; protected set; }
        public DateTime? ValidityDate { get; protected set; }
        public string SuppId { get; protected set; }
        public Supplier Supplier { get; protected set; }


    }
}
