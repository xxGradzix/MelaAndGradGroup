using Logic.Services.Interfaces;

namespace Logic.Services
{
    internal class StateService : IStateService
    {
        public StateService(int stateId, int nrOfProducts, int catalogId)
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
