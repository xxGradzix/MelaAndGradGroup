using Data.States;

namespace Data.API.Entities
{
    public interface IEvent
    {
        public int Id { get; set; }
        public State state { get; set; }
    }
}
