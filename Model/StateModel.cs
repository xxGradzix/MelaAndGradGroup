using Data.Catalogs;
using Model.Interfaces;

namespace Data.States
{
    internal class StateModel: IStateModel
    {
        public StateModel(int stateId, int nrOfProducts, int catalogId)
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
