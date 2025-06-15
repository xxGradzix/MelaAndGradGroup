using Data.API.Entities;

namespace LogicTest.testEntities
{
    internal class TestEvent : IEvent
    {
        public TestEvent(int eventId, TestState state)
        {
            this.eventId = eventId;
            this.state = state;
        }
    }
}
