namespace FacadeV1;

public class CountRows : IStatsOperation
{
    private readonly string _rowName;

    public CountRows(string rowName)
    {
        _rowName = rowName;
    }

    public string GetName()
    {
        return $"Count {_rowName}";
    }

    public object Perform(Table table)
    {
        return table.GetData().Count - 1;
    }
}