using System.Windows.Controls;
using ViewModel;

namespace View
{
    public partial class EventMasterView : UserControl
    {
        public EventMasterView()
        {
            InitializeComponent();
            DataContext = new EventListViewModel();  
        }

    }
}