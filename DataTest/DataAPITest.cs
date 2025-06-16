using Data;
using Data.dataContextImpl;

namespace DataTest;

public class DataAPITest
{

    [Test]
    public void TestAddCatalog()
    {
        DataContext context = new DataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(1, name, price, desc);
        Assert.IsTrue(context.GetCatalog(1).name == name);
    }

    [Test]
    public void TestAddUsers()
    {
        DataContext context = new DataContext();

        string name = "testname";
        context.AddUser(1, name, "password", "email", "123456789");
        Assert.IsTrue(context.GetUser(1).username == "testname");
    }

    [Test]
    public void TestAddState()
    {
        DataContext context = new DataContext();

        
        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(1, name, price, desc);

        int nrOfProducts = 123;
        int catalogId = 0; 
        context.AddState(1, nrOfProducts, catalogId);
        Assert.IsTrue(context.GetCatalog(1).name == name);
    }

    [Test]
    public void TestAddUserEvent()
    {
        DataContext context = new DataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        int catalogId = 1;
        int stateId = 1;
        int userId = 1;
        context.AddCatalog(catalogId, name, price, desc);

        int nrOfProducts = 123;
        context.AddState(stateId, nrOfProducts, catalogId);

        string username = "testname";
        context.AddUser(userId, username, "password", "email", "123456789");

        context.AddEvent(1,stateId);
        Assert.IsTrue(context.GetEvent(1).state.nrOfProducts == nrOfProducts);
    }

    [Test]
    public void TestAddDatabaseEvent()
    {
        DataContext context = new DataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        int catalogId = 1;
        context.AddCatalog(catalogId, name, price, desc);

        int nrOfProducts = 123;
        context.AddState(1, nrOfProducts, catalogId);

        context.AddEvent(1, 1);
        Assert.IsTrue(context.GetEvent(1).state.nrOfProducts == 123);
    }

    [Test]
    public void ChangeState()
    {
       
        DataContext context = new DataContext();

        string name = "Test";
        string desc = "Desc"; 
        int price = 12;
        context.AddCatalog(1, name, price, desc);

        int nrOfProducts = 123;
        context.AddState(1, nrOfProducts, 0);

        context.ChangeState(1, 4);
        Assert.IsTrue(context.GetState(1).nrOfProducts == nrOfProducts + 4);
    }
}
