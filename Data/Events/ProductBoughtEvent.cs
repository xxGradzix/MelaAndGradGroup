
namespace Data.Events
{
    internal class ProductBoughtEvent : Event
    {
        internal Guid userId { get; }
        internal Guid productId { get; }
        internal int quantity { get; }

        internal ProductBoughtEvent(Guid userId, Guid productId, int quantity)
        {
            this.userId = userId;
            this.productId = productId;
            this.quantity = quantity;
        }
    }
}