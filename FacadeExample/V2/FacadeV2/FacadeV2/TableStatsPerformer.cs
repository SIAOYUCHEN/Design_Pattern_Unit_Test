using System.Text;

namespace FacadeV1;

public class TableStatsPerformer
{
    private readonly List<IStatsOperation> _statsOperations = new List<IStatsOperation>();

    public void AddStatsOperation(IStatsOperation statsOperation)
    {
        _statsOperations.Add(statsOperation);
    }

    public void Print(Table table)
    {
        StringBuilder stats = new StringBuilder();
        foreach (var operation in _statsOperations)
        {
            stats.Append(operation.GetName()).Append(": ")
                .Append(operation.Perform(table)).Append("\n");
        }
        Console.WriteLine(stats);
    }
}