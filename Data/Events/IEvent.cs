namespace Data.Events
{
    public abstract class IEvent
    {
        public int eventId { get; set; }
        public IState state { get; set; }
    }
}