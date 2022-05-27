using System;
using System.Collections.Generic;

namespace Models.DTO
{
    public class ProductSupplierView
    {
        public long ProdId { get; set; }
        public string SuppId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProductItemCreateView ProductItem { get; set; }
        public SupplierView Supplier { get; set; }
    }
}
