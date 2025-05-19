using Data.API;
using Data.API.Entities;
using Data.Catalog;
using Data.Users;
using Data.Implementations;

namespace DataTest.TestDataGenerator
{
    internal class HardcodedDataGenerator : IDataGenerator
    {
        private readonly IData _data;

        public HardcodedDataGenerator()
        {
            _data = new InMemoryDataContext();
            AddStaticData();
        }

        public IData GetData() => _data;

        private void AddStaticData()
        {
            IProduct product = new Product("name1", 12, 100, "description1");
            _data.AddProduct(product);

            IUser customer = new Customer("Customer", "customer@mail.com", "password", "123456789");
            _data.AddUser(customer);
        }
    }
}
