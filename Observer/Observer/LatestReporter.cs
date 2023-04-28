namespace Observer
{
    public class LatestReporter : IReporter
    {
        private int latest;

        public int GetLatest() {
            return this.latest;
        }
        
        public void AddQuantity(int quantity) {
            this.latest = quantity;
        }
    }
}