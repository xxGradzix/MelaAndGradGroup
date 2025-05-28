using Presentation.Model.API;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    internal class ProductListViewModel : PropertyChange
    {
        private IModel model;

        private ProductViewModel selectedViewModel;
        private ProductViewModel selectedProduct;

        public ObservableCollection<ProductViewModel> Products { get; } = new();

        public ProductViewModel SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ProductViewModel SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                OnPropertyChanged(nameof(CanModifyProduct));
                SelectedViewModel = selectedProduct;
            }
        }
        public bool CanModifyProduct => SelectedProduct != null;

        public ICommand RefreshCommand { get; }
        public ICommand AddProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand SaveProductCommand { get; }


        public ProductListViewModel()
        {
            Products.Add(new ProductViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Sample Product",
                Price = 10.0,
                Quantity = 100,
                Description = "This is a sample product."
            });
        }

        public ProductListViewModel(IModel model)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));

            RefreshCommand = new RelayCommand(_ => LoadProducts());
            AddProductCommand = new RelayCommand(_ => AddProduct());
            DeleteProductCommand = new RelayCommand(_ => DeleteProduct(), _ => SelectedProduct != null);
            SaveProductCommand = new RelayCommand(_ => SaveProduct(), _ => SelectedProduct != null);

            LoadProducts();
        }

        private void LoadProducts()
        {
            Products.Clear();
            foreach (var product in model.GetAllProducts())
            {
                Products.Add(new ProductViewModel(product));
            }

            if (Products.Count > 0)
            {
                SelectedProduct = Products[0];
            }
        }

        private void AddProduct()
        {
            var newProduct = new ProductViewModel
            {
                Id = Guid.NewGuid(),
                Name = "New Product",
                Price = 0.0,
                Quantity = 0,
                Description = ""
            };

            Products.Add(newProduct);
            SelectedProduct = newProduct;
        }

        private void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                model.DeleteProduct(SelectedProduct.Id);
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
                SelectedViewModel = null;
                OnPropertyChanged(nameof(CanModifyProduct));
            }
        }

        private void SaveProduct()
        {
            if (SelectedProduct == null) return;

            var existing = model.GetProductById(SelectedProduct.Id);
            if (existing != null)
            {
                model.DeleteProduct(existing.id);
            }

            model.AddProduct(
                SelectedProduct.Name,
                SelectedProduct.Price,
                SelectedProduct.Quantity,
                SelectedProduct.Description
            );

            LoadProducts();
        }
    }
}
