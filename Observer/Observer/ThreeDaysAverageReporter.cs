using System.Collections.Generic;
using System.Linq;

namespace Observer
{
    public class ThreeDaysAverageReporter : IReporter
    {
        private List<int> history = new List<int>();

        public double GetThreeDaysAverage()
        {
            return history.Average();
        }
        
        public void AddQuantity(int quantity) {
            history.Add(quantity);
            if (history.Count > 3) {
                history.RemoveAt(0);
            }
        }
    }
}