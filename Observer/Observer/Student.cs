using System;

namespace Observer
{
    public class Student : IObserver
    {
        IObserverable observerable;

        public Student(IObserverable observerable){
            this.observerable = observerable;
        }
        
        public void Update() {
            Console.WriteLine("聽了" + observerable.GetName());
        }
    }
}