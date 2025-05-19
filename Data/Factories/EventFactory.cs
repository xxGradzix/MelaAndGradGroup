using Data.API.Entities;
using Data.Events;

namespace Data.Factories
{
    internal class EventFactory : IEventFactory
    {
        
        public IEvent CreateProductBoughtEvent(Guid userId, Guid productId, int quantity)
        {
            return new ProductBoughtEvent(userId, productId, quantity);
        }
        
        public IEvent CreateProductAddedEvent(Guid itemId, int quantity)
        {
            return new ProductAddedEvent(itemId, quantity);
        }
        
        public IEvent CreateProductRemovedEvent(Guid productId)
        {
            return new ProductRemovedEvent(productId);
        }
        
        public IEvent CreateNewUserAddedEvent(Guid userId, string userEmail)
        {
            return new UserAddedEvent(userId, userEmail);
        }
        
        public IEvent CreateUserRemovedEvent(Guid userId)
        {
            return new UserRemovedEvent(userId);
        }
        public IEvent CreateUserAddedEvent(Guid userId, string username)
        {
            return new UserAddedEvent(userId, username);
        }
        
        public IEvent CreateSellProductEvent(Guid userId, Guid itemId, int quantity)
        {
            return new ProductBoughtEvent(userId, itemId, quantity);
        }
    }
}