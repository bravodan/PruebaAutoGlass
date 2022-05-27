using Kernel.Interfaces;

namespace Domain.Entities
{
    public partial class Supplier : IAggregateRoot
    {
        public Supplier(string id, string description, string phoneNumber)
        {
            this.Update(id, description, phoneNumber);
        }

        public void Update(string id, string description, string phoneNumber)
        {
            this.id = id;
            this.description = description;
            this.phoneNumber = phoneNumber;
        }
    }
}
