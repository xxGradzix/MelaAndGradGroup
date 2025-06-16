using Data.API.Entities;
using Logic.Services.Interfaces;
using LogicLayerTest;

namespace LogicTest.testEntities

{
    internal class TestState : IState
    {
        public TestState(int Id, int nrOfProducts, TestCatalog catalog)
        {
            this.Id = Id;
            this.nrOfProducts = nrOfProducts;
            this.catalog = catalog;
        }

        public int Id { get; set; }
        public int nrOfProducts { get; set; }
        public ICatalog catalog { get; set; }
    }
}
