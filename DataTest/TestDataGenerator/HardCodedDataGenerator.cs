using Data.API;
using Data.API.Entities;
using Data.Catalogs;
using Data.dataContextImpl;
using Data.Users;

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
            // ICatalog product = new Catalog(1, "name1", 12, "description1");
            _data.AddCatalog("name1", 12, "description1");

            // IUser customer = new Customer("Customer", "customer@mail.com", "password", "123456789");
            _data.AddUser("Customer", "password", "customer@mail.com", "123456789");
        }
    }
}
