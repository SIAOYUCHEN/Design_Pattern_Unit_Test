namespace FacadeV1;

public interface IStatsOperation
{
    public string GetName();
    public object Perform(Table table);
}