using ViewModel;

namespace PresentationLayerTest
{
    public class PresentationTest
    {
        [TestFixture]
        public sealed class PresentationTest1
        {
            [Test]
            public void CatalogCollectionTest()
            {
                var model = new TestDataModel();
                var vm = new CatalogListViewModel(model);
                vm.Id = 0;
                vm.Name = "Name";
                vm.Price = 10.0;
                vm.Description = "Description";
                vm.add();
                Assert.That(model.GetAllCatalog().Count(), Is.EqualTo(1));
                vm.delete();
                Assert.That(model.GetAllCatalog().Count(), Is.EqualTo(0));
            }

            [Test]
            public void UsersCollectionTest()
            {
                var model = new TestDataModel();
                var vm = new UserListViewModel(model);
                vm.Id = 0;
                vm.Username = "Username";
                vm.Password = "Password";
                vm.Email = "Email";
                vm.PhoneNumber = "1234567890";
                vm.add();
                Assert.That(model.GetAllUser().Count(), Is.EqualTo(1));
                vm.delete();
                Assert.That(model.GetAllUser().Count(), Is.EqualTo(0));
            }

            [Test]
            public void EventCollectionTest()
            {
                var model = new TestDataModel();
                var vm = new EventListViewModel(model);
                vm.EventId = 0;
                vm.NrOfProducts = 1;
                vm.add();
                Assert.That(model.GetAllEvent().Count(), Is.EqualTo(1));
                vm.delete();
                Assert.That(model.GetAllEvent().Count(), Is.EqualTo(0));
            }

            [Test]
            public void StateCollectionTest()
            {
                var model = new TestDataModel();
                var vm = new StateListViewModel(model);
                vm.StateId = 0;
                vm.NrOfProducts = 1;
                vm.CatalogId = 0;
                vm.add();
                Assert.That(model.GetAllState().Count(), Is.EqualTo(1));
                vm.delete();
                Assert.That(model.GetAllState().Count(), Is.EqualTo(0));
            }
        }
    }
}