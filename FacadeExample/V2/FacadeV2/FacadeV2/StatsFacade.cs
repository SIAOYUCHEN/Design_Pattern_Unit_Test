namespace FacadeV1;

public class StatsFacade
{
    public const int TOTAL_COST = 0x01;
    public const int COUNT_MEMBERS = 0x01 << 1;
    private readonly MarkdownParser _parser = new MarkdownParser();

    public void PrintMarkdownTableStats(string fileName, int statOpsFlag)
    {
        try
        {
            Table table = _parser.ParseTableFromFile(fileName);

            TableStatsPerformer statsPerformer = new TableStatsPerformer();

            if ((statOpsFlag & TOTAL_COST) != 0)
            {
                statsPerformer.AddStatsOperation(new TotalColumn("Cost"));
            }
            if ((statOpsFlag & COUNT_MEMBERS) != 0)
            {
                statsPerformer.AddStatsOperation(new CountRows("Members"));
            }

            statsPerformer.Print(table);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            throw;
        }
    }
}