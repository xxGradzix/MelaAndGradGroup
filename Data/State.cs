using Data.Catalog;
using Data.Events;
    
namespace Data
{
    internal class State: IState
    {
        public State(int stateId, int nrOfBooks, Catalog.Catalog catalog)
        {
            this.stateId = stateId;
            this.nrOfBooks = nrOfBooks;
            this.catalog = catalog;
        }
    }
}
