namespace ProxyV1;

public class Expense
{
    public string Id { get; }
    public string Description { get; }
    public decimal Cost { get; }
    public DateTime CreatedTime { get; }

    public Expense(string description, decimal cost)
        : this(Guid.NewGuid().ToString(), description, cost, DateTime.Now)
    {
    }

    public Expense(string id, string description, decimal cost, DateTime createdTime)
    {
        Id = id;
        Description = description;
        Cost = cost;
        CreatedTime = createdTime;
    }

    public Expense Edit(string description, decimal cost)
    {
        return new Expense(Id, description, cost, CreatedTime);
    }
}