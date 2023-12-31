using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = Deck.Standard52Cards();
        List<Player> players = new List<Player> { new HumanPlayer(), new AI(), new AI(), new AI() };
        Shutdown showdown = new Shutdown(deck, players);
        showdown.Start();
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}