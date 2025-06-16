
using Data.API.Entities;
using Model.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Xml.Linq;

namespace ViewModel
{
    internal class CatalogListViewModel : PropertyChange
    {
        private IDataModel data;
        private int _id;
        private string _name;
        private double _price;
        private string _description;

        private CatalogViewModel selectedCatalog;
        public ObservableCollection<CatalogViewModel> Catalogs { get; set; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand LoadCommand { get; }
        public CatalogListViewModel()
        {
            Catalogs = new ObservableCollection<CatalogViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = IDataModel.CreateNewDataModel();
        }

        public CatalogListViewModel(IDataModel model)
        {
            Catalogs = new ObservableCollection<CatalogViewModel> { };
            AddCommand = new RelayCommand(() => add());
            DeleteCommand = new RelayCommand(() => delete());
            UpdateCommand = new RelayCommand(() => update());
            LoadCommand = new RelayCommand(() => load());
            data = model;
        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public double Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public CatalogViewModel SelectedViewModel
        {
            get => selectedCatalog;
            set
            {
                selectedCatalog = value;
                OnPropertyChanged(nameof(SelectedViewModel));
                if (value != null)
                {
                    Id = value.Id;
                    Name = value.Name;
                    Price = value.Price;
                    Description = value.Description;
                }
            }
        }


        public void add()
        {
            Catalogs.Add(new CatalogViewModel(Id, Name, Price, Description));
            data.AddCatalog(Id, Name, Price, Description);
        }

        public void delete()
        {
            for (int i = Catalogs.Count - 1; i >= 0; i--)
            {
                if (Catalogs[i].Id == Id)
                {
                    Catalogs.RemoveAt(i);
                    break;
                }
            }
            data.RemoveCatalog(Id);
        }

        public void update()
        {
            delete();
            add();
        }

        public void load()
        {
            Catalogs.Clear();
            foreach (var catalog in data.GetAllCatalog())
            {
                Catalogs.Add(new CatalogViewModel(Id = catalog.id, Name = catalog.name, Price = catalog.price, Description = catalog.description));
            }
        }
    }
}
