using Data.API.Entities;

namespace LogicTest.testEntities
{
    internal class TestEvent : IEvent
    {
        public TestEvent(int eventId, TestState state)
        {
            this.Id = eventId;
            this.state = state;
        }

        public int Id { get; set; }
        public IState state { get; set; }
    }
}
