using Data.API.Entities;
using Data.Catalogs;

namespace Data.States
{
    internal class State: IState
    {
        public State(int stateId, int nrOfBooks, Catalog catalog)
        {
            this.stateId = stateId;
            nrOfProducts = nrOfBooks;
            this.catalog = catalog;
        }
    }
}
