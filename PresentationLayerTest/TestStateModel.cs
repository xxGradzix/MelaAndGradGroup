using Model.Interfaces;

namespace PresentationLayerTest
{
    internal class TestStateModel : IStateModel
    {
        public TestStateModel(int stateId, int nrOfProducts, int catalogId)
        {
            this.stateId = stateId;
            this.nrOfProducts = nrOfProducts;
            this.catalogId = catalogId;
        }

        public int stateId { get; set; }
        public int nrOfProducts { get; set; }
        public int catalogId { get; set; }
    }
}