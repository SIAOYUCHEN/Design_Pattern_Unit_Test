using System.Collections.Generic;

namespace Observer
{
    public class Rainfall
    {
        private List<IReporter> reporters = new List<IReporter>();
        
        public void AddQuantity(int quantity) {
            
            foreach (var reporter in reporters)
            {
                reporter.AddQuantity(quantity);
            }
        }

        public void AddReporter(IReporter reporter) {
            this.reporters.Add(reporter);
        }
    }
}