using Model.Interfaces;

namespace Model
{
    internal class CatalogModel: ICatalogModel
    {
        
        public CatalogModel(int id, string name, double price, string description)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}


