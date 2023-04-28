namespace Observer
{
    public interface IObserverable
    {
        void Add(IObserver observer);
        
        void Remove(IObserver observer);

        string GetName();

        void SetName(string newname);
        
        void NotifyObservers();
    }
}