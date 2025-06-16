using Model.Interfaces;

namespace ViewModel
{
    public class CatalogViewModel : PropertyChange, ICatalogModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public double Price
        {
            get => price;
            set { price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        public CatalogViewModel()
        {
            id = 0;
            name = "";
            price = 0;
            description = "";
        }

        public CatalogViewModel(int id, string name, double price, string description)
        {
            this.id= id;
            this.name = name;
            this.price = price;
            this.description = description;
        }
    }
}
