using Data.API.Entities;

namespace Data.Catalogs
{
    internal class Catalog: ICatalog
    {
        
        public Catalog(int id, string name, double price, string description)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
        }
    }
}


