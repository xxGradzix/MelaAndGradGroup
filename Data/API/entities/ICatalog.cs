namespace Data.API.Entities
{
    public abstract class ICatalog
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        // public int quantity { get; set; }

        public string description { get; set; }
        
    }
}
