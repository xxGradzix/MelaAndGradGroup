using System.Windows.Controls;
using ViewModel;

namespace View
{
    public partial class UserMasterView : UserControl
    {
        public UserMasterView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();  

        }
    }
}