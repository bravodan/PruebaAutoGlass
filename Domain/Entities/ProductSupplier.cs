using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ProductSupplier
    {
        public long ProdId { get; protected set; }
        public string SuppId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        
        public ProductItem ProductItem { get; set; }
        public Supplier Supplier { get; set; }
    }
}
