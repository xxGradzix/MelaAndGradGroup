using Data.API.Entities;
using Data.Catalogs;
using Data.States;
using Logic.Services.Interfaces;

namespace LogicTest.testEntities

{
    internal class TestState : State
    {
        public TestState(int Id, int nrOfProducts, TestCatalog catalog)
        {
            this.Id = Id;
            this.nrOfProducts = nrOfProducts;
            this.catalog = catalog;
        }

        public int Id { get; set; }
        public int nrOfProducts { get; set; }
        public TestCatalog catalog { get; set; }
    }
}
