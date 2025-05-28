using System;
using System.ComponentModel;

namespace Presentation.ViewModel
{
    internal class ProductViewModel : PropertyChange
    {
        private Guid _id;
        private string _name;
        private double _price;
        private int _quantity;
        private string _description;

        public ProductViewModel() { }

        public ProductViewModel(Guid id, string name, double price, int quantity, string description)
        {
            _id = id;
            _name = name;
            _price = price;
            _quantity = quantity;
            _description = description;
        }

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
