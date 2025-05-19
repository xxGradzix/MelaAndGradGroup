using Data.API.Entities;

namespace Logic.Repositories.Interfaces
{
    public interface IEventRepository
    {
        void AddEvent(IEvent eventBase);
        List<IEvent> GetAllEvents();
    }
}
