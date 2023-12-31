namespace ConsoleApp1;

public class AI : Player
{
    private static readonly Random random = new Random();

    public override void NameSelf(int order)
    {
        SetName($"AI-{order}");
    }

    protected override ExchangeHands MakeExchangeHandsDecision()
    {
        if (HasUsedExchangeHands())
        {
            return null;
        }
        return random.Next(2) == 0 ? null : RandomlyExchangeHands();
    }

    private ExchangeHands RandomlyExchangeHands()
    {
        List<Player> players = shutdown.GetPlayers();
        return new ExchangeHands(this, players[random.Next(players.Count)]);
    }

    protected override Card ShowCard()
    {
        Hand hand = GetHand();
        if (hand.Size == 1)
        {
            return hand.Get(0);
        }
        return hand.Show(random.Next(hand.Size));
    }
}