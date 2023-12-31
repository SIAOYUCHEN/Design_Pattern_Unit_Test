namespace ConsoleApp1;

public class Shutdown
{
    public static readonly int NumOfRounds = 13;
    private readonly Deck deck;
    private readonly List<Player> players;
    private readonly List<TurnMove> turnMoves = new List<TurnMove>();

    public Shutdown(Deck deck, List<Player> players)
    {
        this.deck = deck;
        this.players = players;
        players.ForEach(p => p.SetShutdown(this));
    }

    public void Start()
    {
        NameThemselves();
        deck.Shuffle();
        DrawHands();
        PlayRounds();
        GameOver();
    }

    private void NameThemselves()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].NameSelf(i + 1);
        }
    }

    private void DrawHands()
    {
        int deckSize = deck.Size;
        for (int i = 0; i < deckSize; i++)
        {
            Card card = deck.Draw();
            players[i % players.Count].AddHandCard(card);
        }
    }

    private void PlayRounds()
    {
        for (int i = 0; i < NumOfRounds; i++)
        {
            players.ForEach(TakeTurn);
            ShowdownRound();
            turnMoves.Clear();
        }
    }

    private void TakeTurn(Player player)
    {
        Console.WriteLine($"It's {player.GetName()}'s turn.");
        TurnMove turnMove = player.TakeTurn();
        turnMoves.Add(turnMove);
    }

    private void ShowdownRound()
    {
        PrintShowCards();
        var winnerTurnMove = turnMoves.MaxBy(tm => tm.GetShowCard());
        var winner = winnerTurnMove.GetPlayer();
        winner.GainPoint();
        Console.WriteLine($"{winner.GetName()} wins this round.");
    }

    private void PrintShowCards()
    {
        Console.Write("Show cards: ");
        Console.WriteLine(string.Join(" ", turnMoves.Select(tm => tm.GetShowCard().ToString())));
    }

    private void GameOver()
    {
        var winner = players.MaxBy(p => p.GetPoint());
        Console.WriteLine($"The winner is {winner.GetName()}.");
    }

    public List<Player> GetPlayers()
    {
        return players;
    }
}