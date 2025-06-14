using Data.Events;
using Data.States;
using Data.Users;

namespace Data.Events
{
    internal class UserEvent: Event
    {
        public User user { get; set; }

        public UserEvent(int eventId, State state, User user) : base(eventId, state)
        {
            this.user = user;
        }
    }
}
