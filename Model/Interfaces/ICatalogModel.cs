namespace Model.Interfaces
{
    public interface ICatalogModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public string description { get; set; }
        
    }
}
