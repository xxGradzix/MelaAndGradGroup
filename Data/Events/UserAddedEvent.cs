

namespace Data.Events
{
    internal class UserAddedEvent : Event
    {
        internal Guid userId { get; private set; }
        internal string userEmail { get; private set; }

        internal UserAddedEvent(Guid userId, string userEmail)
        {
            this.userId = userId;
            this.userEmail = userEmail;
        }

    }
}
