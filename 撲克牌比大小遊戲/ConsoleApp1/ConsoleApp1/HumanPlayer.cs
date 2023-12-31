namespace ConsoleApp1;

public class HumanPlayer : Player
{
    public override void NameSelf(int order)
    {
        Console.Write($"Input your name (P{order}): ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            NameSelf(order);
        }
        else
        {
            SetName(name);
        }
    }

    protected override ExchangeHands MakeExchangeHandsDecision()
    {
        Console.Write("Would you like to perform hands exchange? (y/n): ");
        string answer = Console.ReadLine().ToLower().Trim();
        if (answer.Equals("y"))
        {
            List<Player> players = shutdown.GetPlayers().Where(p => p != this).ToList();
            return SelectExchangeHandsTarget(players);
        }
        else
        {
            return null;
        }
    }

    private ExchangeHands SelectExchangeHandsTarget(List<Player> players)
    {
        PrintPlayerChoices(players);
        if (!int.TryParse(Console.ReadLine(), out int targetIndex) ||
            targetIndex >= players.Count || targetIndex < 0)
        {
            return SelectExchangeHandsTarget(players);
        }
        return new ExchangeHands(this, players[targetIndex]);
    }

    private void PrintPlayerChoices(List<Player> players)
    {
        Console.Write("Select the target ");
        for (int i = 0; i < players.Count; i++)
        {
            Console.Write($"({i}) {players[i].GetName()} ");
        }
        Console.WriteLine();
    }

    protected override Card ShowCard()
    {
        PrintCardSelections();
        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 0 || choice >= GetHand().Size)
        {
            return ShowCard();
        }
        return GetHand().Show(choice);
    }

    private void PrintCardSelections()
    {
        Console.WriteLine("Select the card to play:");
        for (int i = 0; i < GetHand().Size; i++)
        {
            string cardRepresentation = GetHand().Get(i).ToString();
            Console.Write($"{i.ToString().PadRight(cardRepresentation.Length)} ");
        }
        Console.WriteLine();
        for (int i = 0; i < GetHand().Size; i++)
        {
            string cardRepresentation = GetHand().Get(i).ToString();
            Console.Write($"{cardRepresentation} ");
        }
        Console.WriteLine();
    }
}