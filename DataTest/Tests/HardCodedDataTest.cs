using DataTest.TestDataGenerator;

namespace DataTest.Tests
{
    
    
    public class HardcodedDataTest : DataTest
    {
        [SetUp]
        public override void Initialize()
        {
            IDataGenerator generator = new HardcodedDataGenerator();
            _data = generator.GetData();
        }

        [Test]
        public void TestStaticProduct()
        {
            Assert.AreEqual(1, _data.GetAllCatalog().Count, "Incorrect number of products");
        }

        [Test]
        public void TestStaticUser()
        {
            Assert.AreEqual(1, _data.GetAllUser().Count, "Incorrect number of users");
        }
    }
}
