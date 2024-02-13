
using FacadeV1;

class Program
{
    static void Main(string[] args)
    {
        StatsFacade statsFacade = new StatsFacade();
        try
        {
            statsFacade.PrintMarkdownTableStats("data.table",
                StatsFacade.TOTAL_COST | StatsFacade.COUNT_MEMBERS);
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