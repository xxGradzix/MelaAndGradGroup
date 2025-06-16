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
    }
}