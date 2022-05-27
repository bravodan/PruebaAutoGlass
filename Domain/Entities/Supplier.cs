using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Supplier
    {
        public string id { get; protected set; }
        public string description { get; protected set; }
        public string phoneNumber { get; protected set; }
        public List<ProductSupplier> ProductSupplierList { get; set; }
    }
}
