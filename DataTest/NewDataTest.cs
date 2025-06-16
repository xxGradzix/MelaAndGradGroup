using Data.Catalogs;
using Data.Events;
using Data.States;
using Data.Users;

namespace DataTest
{
    public sealed class NewDataTest
    {
        [Test]
        public void TestConstructorCatalog()
        { 
            Catalog c = new Catalog(1, "test", 1234.0, "desc");
            Assert.IsTrue(c.id == 1 && c.name == "test" && 
                          c.description == "desc" && c.price == 1234.0);
        }

        [Test]
        public void TestConstructorState()
        {
            Catalog c = new Catalog(1, "test", 1234, "desc");
            State s = new State(1, 10, c);
            Assert.IsTrue(s.Id == 1 && s.catalog == c);
        }

        [Test]
        public void TestConstructorEvent()
        {
            Catalog c = new Catalog(1, "test", 1234, "desc");
            State s = new State(1, 10, c);
            Event e = new Event(1, s);
            Assert.IsTrue(e.Id == 1 && e.state == s);
        }

        [Test]
        public void TestConstructorUserEvent()
        {
            Catalog c = new Catalog(1, "test", 1234, "desc");
            User u = new User(1, "Marcin", "test1234", "mail.mail.com", "123456789");
            State s = new State(1, 10, c);
            Event e = new Event(1, s);
            Assert.IsTrue(e.Id == 1 && e.state == s);
        }

        [Test]
        public void TestConstructorDatabaseEvent()
        {
            Catalog c = new Catalog(1, "test", 1234, "desc");
            State s = new State(1, 10, c);
            Event e = new Event(1, s);
            Assert.IsTrue(e.Id == 1 && e.state == s);
        }

        [Test]
        public void TestConstructorUsers()
        {
            User u = new User(1, "Marcin", "test1234", "mail.mail.com", "123456789");
            Assert.IsTrue(u.id == 1 && u.username == "Marcin" && u.password == "test1234");
        }
    }
}
