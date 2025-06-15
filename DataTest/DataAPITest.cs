using Data;
using Data.dataContextImpl;

namespace DataTest;

public class DataAPITest
{

    [Test]
    public void TestAddCatalog()
    {
        InMemoryDataContext context = new InMemoryDataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(name, price, desc);
        Assert.IsTrue(context.catalogs[0].name == name);
    }

    [Test]
    public void TestAddUsers()
    {
        InMemoryDataContext context = new InMemoryDataContext();

        string name = "testname";
        context.AddUser(name, "password", "email", "123456789");
        Assert.IsTrue(context.users[0].username == "testname");
    }

    [Test]
    public void TestAddState()
    {
        InMemoryDataContext context = new InMemoryDataContext();

        
        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(name, price, desc);

        int nrOfProducts = 123;
        int catalogId = 0; 
        context.AddState(nrOfProducts, catalogId);
        Assert.IsTrue(context.catalogs[0].name == name);
    }

    [Test]
    public void TestAddUserEvent()
    {
        InMemoryDataContext context = new InMemoryDataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(name, price, desc);

        int nrOfProducts = 123;
        int catalogId = 0; 
        context.AddState(nrOfProducts, catalogId);

        string username = "testname";
        context.AddUser(username, "password", "email", "123456789");

        context.AddUserEvent(0,0);
        Assert.IsTrue(context.events[0].state.nrOfProducts == nrOfProducts);
    }

    [Test]
    public void TestAddDatabaseEvent()
    {
        InMemoryDataContext context = new InMemoryDataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(name, price, desc);

        int nrOfProducts = 123;
        int catalogId = 0; 
        context.AddState(nrOfProducts, catalogId);

        context.AddDatabaseEvent(0);
        Assert.IsTrue(context.events[0].state.nrOfProducts == 123);
    }

    [Test]
    public void ChangeState()
    {
       
        InMemoryDataContext context = new InMemoryDataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(name, price, desc);

        int nrOfProducts = 123;
        context.AddState(nrOfProducts, 0);

        context.ChangeState(0, 4);
        Assert.IsTrue(context.states[0].nrOfProducts == nrOfProducts);
    }
}
