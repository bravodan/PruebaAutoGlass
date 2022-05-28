
using System;

namespace Domain.QueryParams
{
    public class ProductItemParameters : GenericQueryParams
    {
        public string Description { get; set; }
        public uint MaxManufacturingYear { get; set; } 
        public uint MinManufacturingYear { get; set; }
        private bool ValidDateRange => MaxManufacturingYear >= MinManufacturingYear;

        public bool getValidDateRange()
        {
            return ValidDateRange;
        }
    }
}
