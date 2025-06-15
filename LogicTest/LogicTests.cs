using Logic;
using Logic.Services;

namespace LogicLayerTest
{
    public sealed class LogicTests
    {

        [Test]
        public void TestBorrowCatalog()
        {
            DataService ds = new DataService();
            try
            {
                ds.BuyCatalog(1, 1);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [Test]
        public void TestReturnCatalog()
        {
            DataService ds = new DataService();
            try
            {
                ds.SellCatalog(1, 1);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [Test]
        public void TestDestroyCatalog()
        {
            DataService ds = new DataService();
            try
            {
                ds.RemoveCatalog(1);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [Test]
        public void TestAddCatalog()
        {
            DataService ds = new DataService();
            try
            {
                ds.AddCatalog(1);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }
    }
}
