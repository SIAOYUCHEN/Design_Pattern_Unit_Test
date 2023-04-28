using System;
using System.Collections.Generic;

namespace Observer
{
    public class PodcastA : IObserverable
    {
        List<IObserver> list = new List<IObserver>();

        //節目名稱
        string name = "英文廣播";
        
        public void Add(IObserver observer) {
            list.Add(observer);
        }
        
        public void Remove(IObserver observer) {
            list.Remove(observer);
        }

        public String GetName() {
            return this.name;
        }

        public void SetName(string newname)
        {
            this.name = newname;
        }
        
        public void NotifyObservers() {
            
            foreach (var temp in list)
            {
                temp.Update();
            }
        }
    }
}