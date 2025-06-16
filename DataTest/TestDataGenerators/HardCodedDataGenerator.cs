using Data.API;
using Data.API.Entities;
using Data.Catalogs;
using Data.dataContextImpl;
using Data.Users;

namespace DataTest.TestDataGenerators
{
    internal class HardcodedDataGenerator : IDataGenerator
    {
        private readonly IData _data;

        public HardcodedDataGenerator()
        {
            _data = new DataContext();
            AddStaticData();
        }

        public IData GetData() => _data;

        private void AddStaticData()
        {
            _data.AddCatalog(1, "name1", 12, "description1");

            _data.AddUser(1, "name", "password", "customer@mail.com", "123456789");
            
            _data.AddState(1, 1, 1);
            
            _data.AddEvent(1, 1);
            
        }
    }
}
