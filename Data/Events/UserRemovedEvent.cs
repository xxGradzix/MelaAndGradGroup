
namespace Data.Events
{
    internal class UserRemovedEvent : Event
    {
        internal Guid userId { get; private set; }

        internal UserRemovedEvent(Guid userId)
        {
            this.userId = userId;
        }

    }
}
