using Data.API.Entities;
using Data.Catalogs;

namespace Data.States
{
    public class State: IState
    {
        
        public int Id { get; set; }
        public int nrOfProducts { get; set; }
        public Catalog catalog { get; set; }
        
        public State(int Id, int nrOfProducts, Catalog catalog)
        {
            this.Id = Id;
            this.nrOfProducts = nrOfProducts;
            this.catalog = catalog;
        }
        
        public State()
        {
        }
    }
}
