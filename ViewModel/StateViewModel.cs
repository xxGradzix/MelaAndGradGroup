using Model.Interfaces;

namespace ViewModel
{
    public class StateViewModel : PropertyChange, IStateModel
    {
        public int stateId { get; set; }
        public int nrOfProducts { get; set; }
        public int catalogId { get; set; }
        public int StateId
        {
            get => stateId;
            set { stateId = value; OnPropertyChanged(nameof(StateId)); }
        }
        public int NrOfProducts
        {
            get => nrOfProducts;
            set { nrOfProducts = value; OnPropertyChanged(nameof(NrOfProducts)); }
        }
        public int CatalogId
        {
            get => catalogId;
            set { catalogId = value; OnPropertyChanged(nameof(CatalogId)); }
        }

        public StateViewModel(int stateId, int nrOfProducts, int catalogId)
        {
            this.stateId = stateId;
            this.nrOfProducts = nrOfProducts;
            this.catalogId = catalogId;
        }
        public StateViewModel()
        {
            StateId = 0;
            nrOfProducts = 0;
            CatalogId = 0;
        }
    }
}
