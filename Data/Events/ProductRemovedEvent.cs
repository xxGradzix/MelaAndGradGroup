
namespace Data.Events
{
    internal class ProductRemovedEvent : Event
    {
        internal Guid productId { get; }

        internal ProductRemovedEvent(Guid productId)
        {
            this.productId = productId;
        }

    }
}
