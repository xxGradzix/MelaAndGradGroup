using Data.Events;
using Data.States;

namespace LogicTest.testEntities
{
    internal class TestEvent : Event
    {
        public TestEvent(int eventId, TestState state)
        {
            this.Id = eventId;
            this.state = state;
        }

        public int Id { get; set; }
        public TestState state { get; set; }
    }
}
