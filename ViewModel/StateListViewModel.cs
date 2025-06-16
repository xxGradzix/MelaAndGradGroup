using Data.API.Entities;
using Model.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class StateListViewModel : PropertyChange
    {
        private IDataModel data;
        private int _stateId;
        private int _nrOfProducts;
        private int _catalogId;

        private StateViewModel selectedState;
        public ObservableCollection<StateViewModel> States { get; set; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand LoadCommand { get; }
        public StateListViewModel()
        {
            States = new ObservableCollection<StateViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = IDataModel.CreateNewDataModel();
        }

        public StateListViewModel(IDataModel model)
        {
            States = new ObservableCollection<StateViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = model;
        }

        public int StateId
        {
            get => _stateId;
            set { _stateId = value; OnPropertyChanged(nameof(StateId)); }
        }

        public int NrOfProducts
        {
            get => _nrOfProducts;
            set { _nrOfProducts = value; OnPropertyChanged(nameof(NrOfProducts)); }
        }

        public int CatalogId
        {
            get => _catalogId;
            set { _catalogId = value; OnPropertyChanged(nameof(CatalogId)); }
        }   

        public StateViewModel SelectedViewModel
        {
            get => selectedState;
            set
            {
                selectedState = value;
                OnPropertyChanged(nameof(SelectedViewModel));
                if (value != null)
                {
                    StateId = value.StateId;
                    NrOfProducts = value.NrOfProducts;
                    CatalogId = value.CatalogId;
                }
            }
        }


        public void add()
        {
            States.Add(new StateViewModel(StateId, NrOfProducts, CatalogId));
            data.AddState(StateId, NrOfProducts, CatalogId);
        }

        public void delete()
        {
            for (int i = States.Count - 1; i >= 0; i--)
            {
                if (States[i].StateId == StateId)
                {
                    States.RemoveAt(i);
                    break;
                }
            }
            data.RemoveState(StateId);
        }

        public void update()
        {
            delete();
            add();
        }

        public void load()
        {
            States.Clear();
            foreach (var state in data.GetAllState())
            {
                States.Add(new StateViewModel(StateId = state.stateId, NrOfProducts = state.nrOfProducts, CatalogId = state.catalogId));
            }
        }
    }
}
