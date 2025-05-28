using Presentation.Model;
using Presentation.Model.API;
using System;

namespace Presentation.ViewModel
{
    internal class ProductViewModel : PropertyChange
    {
        private Guid id;
        private string name = string.Empty;
        private double price;
        private int quantity;
        private string description = string.Empty;

        public Guid Id
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

        public int Quantity
        {
            get => quantity;
            set { quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        public ProductViewModel() { }

        public ProductViewModel(IProductModelData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Id = data.id;
            Name = data.name;
            Price = data.price;
            Quantity = data.quantity;
            Description = data.description;
        }

        public static ProductViewModel FromModel(IProductModelData model)
        {
            return new ProductViewModel
            {
                Id = model.id,
                Name = model.name,
                Price = model.price,
                Quantity = model.quantity,
                Description = model.description
            };
        }

        public IProductModelData ToModel()
        {
            return new ProductModelData(Id, Name, Price, Quantity, Description);
        }
    }
}
