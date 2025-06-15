using Data.API.Entities;
using Data.Events;
using Data.States;
using Data.Users;

namespace Data.Events
{
    internal class UserEvent: Event
    {
        public IUser user { get; set; }

        public UserEvent(int eventId, IState state, IUser user) : base(eventId, state)
        {
            this.user = user;
        }
    }
}
