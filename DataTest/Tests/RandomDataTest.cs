using DataTest.TestDataGenerator;

namespace DataTest.Tests
{
    public class RandomDataTest : DataTest
    {
        [SetUp]
        public override void Initialize()
        {
            IDataGenerator generator = new RandomDataGenerator();
            _data = generator.GetData();
        }

        [Test]
        public void TestGeneratedProdcuts()
        {
            Assert.IsTrue(_data.GetAllCatalog().Count > 0, "No products generated");
        }

        [SetUp]
        public void TestGeneratedUsers()
        {
            Assert.IsTrue(_data.GetAllUser().Count > 0, "No users generated");
        }
    }
}
