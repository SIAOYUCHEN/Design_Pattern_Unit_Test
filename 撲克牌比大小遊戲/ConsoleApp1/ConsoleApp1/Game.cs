namespace ConsoleApp1;

public class Game
{
    private Deck deck;
    private List<Player> players;
    private int roundCounter = 0;
    
    public Game(List<string> playerNames)
    {
        deck = new Deck();
        players = playerNames.Select(name => new Player(name)).ToList();
    }
    
    public void StartGame()
    {
        Console.WriteLine("遊戲開始...");
        
        deck.Shuffle();
        
        foreach (var player in players)
        {
            player.DrawHand(deck);

            Console.WriteLine($"{player.ShowCard()} has drawn 13 cards.");
        }
    }
    
    public void PlayTurn()
    {
        // 回合規則
    }
}