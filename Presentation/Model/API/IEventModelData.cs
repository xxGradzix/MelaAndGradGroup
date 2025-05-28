namespace Presentation.Model.API
{
    public interface IEventModelData
    {
        Guid eventId { get; }
        DateTime timestamp { get; set; }
    }
}