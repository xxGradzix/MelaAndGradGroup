using Data.API;
using Data.dataContextImpl;
using DataTest.TestDataGenerators;

namespace DataTest.Tests
{
    public class DataGenerationTest
    {
        private static string testConnectionString;

        // [SetUp]
        // public static void ClassInitialize(TestContext context)
        // {
        //     string relativePath = @"Database\LibraryLINQDatabaseTest.mdf";
        //     string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        //     string dbPath = Path.Combine(baseDir, relativePath);
        //
        //     Assert.IsTrue(File.Exists(dbPath), $"Database file not found at: {dbPath}");
        //
        //     testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
        // }

        // [SetUp]
        // public void TestInitialize()
        // {
        //     _context = IData.CreateNewContext();
        //     // clear all
        //     _context.TruncateData();
        // }


        [Test]
        public void TestHardcodedDataGenerator()
        {
            IDataGenerator generator = new HardcodedDataGenerator();
            IData _context = generator.GetData();

            var catalog = _context.GetCatalog(1);
            Assert.IsNotNull(catalog);
            Assert.AreEqual("name1", catalog.name);

            var reader = _context.GetUser(1);
            Assert.IsNotNull(reader);
            Assert.AreEqual("name", reader.username);

            var state = _context.GetState(1);
            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.nrOfProducts);

            var events = _context.GetAllEvent().ToList();
            Assert.AreEqual(1, events.Count);
            Assert.AreEqual(1, events[0].Id);
        }

        [Test]
        public void TestRandomDataGenerator()
        {
            IDataGenerator generator = new RandomDataGenerator();
            
            IData _context = generator.GetData();

            Assert.IsTrue(_context.GetAllCatalog().Any(), "No books were added.");
            Assert.IsTrue(_context.GetAllUser().Any(), "No readers were added.");
            Assert.IsTrue(_context.GetAllState().Any(), "No states were added.");
            Assert.IsTrue(_context.GetAllEvent().Any(), "No events were added.");
        }
    }
}