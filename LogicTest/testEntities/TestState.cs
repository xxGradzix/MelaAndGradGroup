using Data.API.Entities;
using Logic.Services.Interfaces;
using LogicLayerTest;

namespace LogicTest.testEntities

{
    internal class TestState : IState
    {
        public TestState(int stateId, int nrOfProducts, TestCatalog catalog)
        {
            this.stateId = stateId;
            this.nrOfProducts = nrOfProducts;
            this.catalog = catalog;
        }
    }
}
