using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Supplier
    {
        public string Id { get; protected set; }
        public string Description { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public List<ProductItem> ProductItemList { get; set; }
    }
}
