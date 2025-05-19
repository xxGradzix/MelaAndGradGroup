using DataTest.TestDataGeneration;
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
            Assert.IsTrue(_data.getProducts().Count > 0, "No products generated");
        }

        [SetUp]
        public void TestGeneratedUsers()
        {
            Assert.IsTrue(_data.GetUsers().Count > 0, "No users generated");
        }
    }
}
