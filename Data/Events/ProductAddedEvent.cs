
namespace Data.Events
{
    internal class ProductAddedEvent : Event
    {
        internal Guid id { get; private set; }
        internal int? quantity { get; }

        internal ProductAddedEvent(Guid id, int quantity) {
            this.id = id;
            this.quantity = quantity;
        }

    }
}
