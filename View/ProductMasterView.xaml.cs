using System.Windows.Controls;
using ViewModel;

namespace View
{
    public partial class ProductMasterView : UserControl
    {
        public ProductMasterView()
        {
            InitializeComponent();
            DataContext = new CatalogListViewModel();  

        }

        private void ProductDetailView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}