using System.Globalization;

namespace FacadeV1;

public class TotalColumn : IStatsOperation
{
    private readonly string _fieldName;

    public TotalColumn(string fieldName)
    {
        _fieldName = fieldName;
    }

    public string GetName()
    {
        return $"Total {_fieldName}";
    }

    public object Perform(Table table)
    {
        return table.GetColumn(_fieldName)
            .Select(value => double.Parse(value, CultureInfo.InvariantCulture))
            .Sum();
    }
}