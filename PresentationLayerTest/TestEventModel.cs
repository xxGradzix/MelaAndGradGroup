using Model.Interfaces;

namespace PresentationLayerTest
{
    internal class TestEventModel : IEventModel
    {
        public TestEventModel(int eventId, int nrOfProducts)
        {
            this.eventId = eventId;
            this.nrOfProducts = nrOfProducts;
        }

        public int eventId { get; set; }
        public int nrOfProducts { get; set; }
    }
}
