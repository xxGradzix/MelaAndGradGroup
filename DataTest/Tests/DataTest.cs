using Data.API;

namespace DataTest.Tests
{
    public abstract class DataTest
    {
        protected IData _data;

        [SetUp]
        public abstract void Initialize();
    }
}
