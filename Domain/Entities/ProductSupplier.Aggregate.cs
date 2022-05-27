using System;

namespace Domain.Entities
{
    public partial class ProductSupplier
    {
        public ProductSupplier(long prodId, string suppId, DateTime startDate, DateTime? endDate)
        {
            Update(prodId, suppId, startDate, endDate);
        }

        public void Update(long prodId, string suppId, DateTime startDate, DateTime? endDate)
        {
            ProdId = prodId;
            SuppId = suppId;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
