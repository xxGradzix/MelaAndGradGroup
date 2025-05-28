using Presentation.Model.API;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    internal class ProductListViewModel : PropertyChange
    {
        private readonly IProductModelData _model;
        private ProductViewModel _selectedProduct;

        public ObservableCollection<ProductViewModel> Products { get; private set; }

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProductViewModel SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public ProductListViewModel() : this(IProductModelData.CreateModel()) { }

        public ProductListViewModel(IProductModelData model)
        {
            _model = model;
            Products = new ObservableCollection<ProductViewModel>();

            LoadCommand = new RelayCommand(async _ => await LoadProductsAsync());
            AddCommand = new RelayCommand(async _ => await AddProductAsync(), _ => SelectedProduct != null);
            DeleteCommand = new RelayCommand(async _ => await DeleteProductAsync(), _ => SelectedProduct != null);
        }

        private ProductViewModel ToViewModel(IProductModelData model)
        {
            return new ProductViewModel(model.id, model.name, model.price, model.quantity, model.description);
        }

        private async Task LoadProductsAsync()
        {
            Products.Clear();
            var allProducts = await _model.GetAllProductsAsync();
            foreach (var product in allProducts)
            {
                Products.Add(ToViewModel(product));
            }
        }

        private async Task AddProductAsync()
        {
            if (SelectedProduct == null)
                return;

            await _model.AddProductAsync(
                SelectedProduct.Id,
                SelectedProduct.Name,
                SelectedProduct.Price,
                SelectedProduct.Quantity,
                SelectedProduct.Description
            );

            await LoadProductsAsync();
        }

        private async Task DeleteProductAsync()
        {
            if (SelectedProduct == null)
                return;

            await _model.DeleteProductAsync(SelectedProduct.Id);
            await LoadProductsAsync();
        }
    }
}
