namespace FacadeV1;

public class Table
{
    private readonly List<string> _header;
    private readonly List<List<string>> _data;

    public Table(List<List<string>> data)
    {
        _header = data[0];
        _data = data;
    }

    public List<string> GetColumn(string fieldName)
    {
        int column = _header.IndexOf(fieldName);
        return _data.Skip(1)
            .Select(row => row[column])
            .ToList();
    }

    public List<string> GetRow(int row)
    {
        return _data[row];
    }

    public List<List<string>> GetRows()
    {
        return _data.Skip(1).ToList();
    }

    public List<List<string>> GetData()
    {
        return _data;
    }
}