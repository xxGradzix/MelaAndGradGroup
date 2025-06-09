using Data.API.Entities;
using Data.Catalog;
using Data.Repositories.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUserRepository userRepository;
        private readonly IProductRepository productRepository;
        private readonly IEventService eventService;
        private readonly IEventFactory eventFactory;

        public ProductService(
        IUserRepository userRepository,
        IProductRepository repository,
        IEventService eventService,
        IEventFactory eventFactory)
        {
            this.userRepository = userRepository;
            this.productRepository = repository;
            this.eventService = eventService;
            this.eventFactory = eventFactory;
        }

        public IProduct AddProduct(IProduct iproduct)
        {
            if (productRepository.FindByID(iproduct.id) != null)
            {
                throw new InvalidOperationException("Error, cannot add another item with the same id.");
            }

            eventService.AddEvent(eventFactory.CreateProductAddedEvent(iproduct.id, iproduct.quantity));

            productRepository.Save((Product)iproduct);
            return iproduct;
        }

        public bool DeleteProductById(Guid id)
        {
            var product = productRepository.FindByID(id);
            if (product == null)
            {
                return false;
            }
            eventService.AddEvent(eventFactory.CreateProductRemovedEvent(product.id));
            productRepository.Delete(product.id);
            return true;
        }

        public IProduct? FindById(Guid id)
        {
            var product = productRepository.FindByID(id);
            if (product == null)
            {
                return        null;        
            }

            return product;
        }

        public List<IProduct> FindAll()
        {
            var products = productRepository.FindAll();
            if (products.Count == 0)
            {
                // throw new InvalidOperationException("Error, no products found.");
                return new List<IProduct>();
            }
            return products.Cast<IProduct>().ToList();
        }

        public IProduct SellProduct(Guid productId, Guid userId, int quantity)
        {
            // Console.WriteLine($"GetUser called with id: {userId}");

            var user = userRepository.FindByID(userId);
            if (user == null)
                throw new InvalidOperationException("Error, user does not exist.");

            var product = productRepository.FindByID(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Error, product with ID {productId} not found.");
            }
            if (product.quantity < quantity)
            {
                throw new InvalidOperationException("Error, not enough quantity in stock. Available: {product.quantity}, Requested: {quantity}");
            }

            product.quantity -= quantity;
            productRepository.Save(product);
            eventService.AddEvent(eventFactory.CreateSellProductEvent(userId, productId, product.quantity));

            return product;
        }

    }
}
