using Data.API.Entities;
using Data.Events;

namespace Data.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event, Guid>
    {
    }
}
