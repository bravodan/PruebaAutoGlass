using Domain.Enums;
using System;

namespace Models.DTO
{
    public class ProductItemCreateView
    {
        public string Description { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ValidityDate { get; set; }
        public string CurrentSupplierId { get; set; }
    }
}
