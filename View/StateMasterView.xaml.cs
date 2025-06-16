using System.Windows.Controls;
using ViewModel;

namespace View
{
    public partial class StateMasterView : UserControl
    {
        public StateMasterView()
        {
            InitializeComponent();
            DataContext = new StateListViewModel();  
        }
    }
}