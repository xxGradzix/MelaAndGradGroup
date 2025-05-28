using Logic.Services.Interfaces;
using Presentation.Model.API;
using System;
using System.Collections.Generic;
using Data.API.Entities;
using Data.Catalog;
using Data.Events;

namespace Presentation.Model
{
    internal class ModelData : IModel
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly IEventService eventService;

        public ModelData(IProductService productService, IUserService userService, IEventService eventService)
        {
            this.productService = productService;
            this.userService = userService;
            this.eventService = eventService;
        }

        // Produkty
        public List<IProductModelData> GetAllProducts()
        {
            List<IProductModelData> result = new();
            foreach (var product in productService.FindAll())
            {
                result.Add(new ProductModelData(
                    product.id, product.name, product.price, product.quantity, product.description
                ));
            }
            return result;
        }

        public IProductModelData? GetProductById(Guid id)
        {
            var product = productService.FindById(id);
            if (product == null) return null;
            return new ProductModelData(product.id, product.name, product.price, product.quantity, product.description);
        }

        public void AddProduct(string name, double price, int quantity, string description)
        {
            var created = productService.AddProduct(new Product(name, price, quantity, description));
        }

        public bool DeleteProduct(Guid id)
        {
            return productService.DeleteProductById(id);
        }

        public void SellProduct(Guid productId, Guid userId, int quantity)
        {
            productService.SellProduct(productId, userId, quantity);
        }

        // Użytkownicy
        public void RegisterUser(string username, string password, string email, string phoneNumber)
        {
            userService.Register(username, password, email, phoneNumber);
        }

        public bool Login(string username, string password)
        {
            return userService.Login(username, password);
        }

        public bool RemoveUser(Guid id)
        {
            return userService.Remove(id);
        }

        public IUserModelData? GetUserById(Guid id)
        {
            var user = userService.GetById(id);
            if (user == null) return null;
            return new UserModelData(user.id, user.username, user.password, user.email, user.phoneNumber, RoleMapper.ToRoleModel(user.role));
        }

        public List<IUserModelData> GetAllUsers()
        {
            List<IUserModelData> result = new();
            foreach (var user in userService.FindAll())
            {
                result.Add(new UserModelData(user.id, user.username, user.password, user.email, user.phoneNumber, RoleMapper.ToRoleModel(user.role)));
            }
            return result;
        }

        // Eventy
        public void AddEvent(Guid id, DateTime timestamp)
        {
            //eventService.AddEvent(new Event(id, timestamp));
        }

        public List<IEventModelData> GetAllEvents()
        {
            List<IEventModelData> result = new();
            foreach (var ev in eventService.GetAllEvents())
            {
                result.Add(new EventModelData(ev.eventId, ev.timestamp));
            }
            return result;
        }
    }
}