using Data.API.Entities;
using Data.Catalogs;

namespace Data.States
{
    internal class State: IState
    {
        public State(int stateId, int nrOfProducts, ICatalog catalog)
        {
            this.stateId = stateId;
            this.nrOfProducts = nrOfProducts;
            this.catalog = catalog;
        }
    }
}
