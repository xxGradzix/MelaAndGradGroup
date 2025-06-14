namespace Data.API.Entities
{
    public abstract class IState
    {
        public int stateId { get; set; }
        public int nrOfProducts { get; set; }
        public ICatalog catalog { get; set; }
    }
}
