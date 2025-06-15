namespace Logic.Services.Interfaces
{
    public interface ICatalogService
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
