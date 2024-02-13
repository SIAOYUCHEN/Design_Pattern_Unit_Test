
using FacadeV1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            MarkdownParser parser = new MarkdownParser();
            Table table = parser.ParseTableFromFile("data.table");
            TableStatsPerformer statsPerformer = new TableStatsPerformer();
            statsPerformer.AddStatsOperation(new TotalColumn("Cost"));
            statsPerformer.AddStatsOperation(new CountRows("Members"));
            statsPerformer.Print(table);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}