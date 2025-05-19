namespace Data.API.Entities
{
    public interface IEvent
    {
        Guid eventId { get; }
        DateTime timestamp { get; set; }
    }
}
