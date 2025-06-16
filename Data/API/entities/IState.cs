using Data.Catalogs;

namespace Data.API.Entities
{
    public interface IState
    {
        public int Id { get; set; }
        public int nrOfProducts { get; set; }
        public Catalog catalog { get; set; }
    }
}
