using Data.API.Entities;

namespace Logic.Services.Interfaces
{
    public interface IStateService
    {
        public int stateId { get; set; }
        public int nrOfProducts { get; set; }
        public int catalogId { get; set; }
    }
}
