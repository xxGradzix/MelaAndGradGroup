namespace Data.API.Entities
{
    public interface IEventFactory
    {
        IEvent CreateProductBoughtEvent(Guid userId, Guid productId, int quantity);
        IEvent CreateProductAddedEvent(Guid productId, int quantity);
        IEvent CreateProductRemovedEvent(Guid productId);
        IEvent CreateNewUserAddedEvent(Guid userId, string userEmail);
        IEvent CreateUserRemovedEvent(Guid userId);
        IEvent CreateUserAddedEvent(Guid id, string username);
        IEvent CreateSellProductEvent(Guid userId, Guid itemId, int quantity);
    }
}
