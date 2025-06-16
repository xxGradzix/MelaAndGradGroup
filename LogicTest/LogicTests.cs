using Logic;
using Logic.Services;
using LogicLayerTest;

namespace LogicTest
{
    public sealed class LogicTests
    {
        [Test]
        public void CatalogTests()
        {
            TestDataContext context = new TestDataContext();
            // DataContext context = new DataContext()();
            DataService service = new DataService(context);
            service.AddCatalog(1, "namer", 1, "desc");
            Assert.AreEqual(service.GetCatalog(1).name, "namer");
            Assert.IsTrue(service.GetCatalog(1).price == 1);
            Assert.IsTrue(service.GetCatalog(1).description == "desc");
        }
        [Test]
        public void UserTests()
        {
            TestDataContext context = new TestDataContext();
            DataService service = new DataService(context);
            service.AddUser(0, "namer", "pass", "email", "123456789");
            Assert.IsTrue(service.GetUser(0).password == "pass");
            Assert.IsTrue(service.GetUser(0).email == "email");
        }
        [Test]
        public void EventTests()
        {
            TestDataContext context = new TestDataContext();
            DataService service = new DataService(context);
            service.AddCatalog(0, "t", 1, "1");
            
            service.AddState(0, 1, 0);
            
            service.AddEvent(0, 0);
            var eventService = service.GetEvent(0);
            
            Console.WriteLine(eventService.stateId);

            Assert.IsTrue(eventService.stateId == service.GetState(0).stateId);
        }
        [Test]
        public void StateTests()
        {
            TestDataContext context = new TestDataContext();
            DataService service = new DataService(context);
            service.AddCatalog(0, "t", 1, "1");
            service.AddState(0, 1, 0);
            Assert.IsTrue(service.GetState(0).nrOfProducts == 1);
            Assert.IsTrue(service.GetState(0).catalogId == service.GetCatalog(0).id);
        }
    }
}
