namespace ConsoleApp1;

public class Player
{
    private string name;
    private List<Card> hand;
    private int points;
    private bool hasExchanged;
    
    public Player(string name)
    {
        this.name = name;
        this.hand = new List<Card>();
        this.points = 0;
        this.hasExchanged = false;
    }
    
    public void AddPoint()
    {
        points++;
    }

    public void ResetExchange()
    {
        hasExchanged = false;
    }
    
    public void DrawHand(Deck deck)
    {
        for (int i = 0; i < 13; i++)
        {
            hand.Add(deck.DrawCard());
        }
    }
    
    public Card ShowCard()
    {
        if (hand.Count == 0)
        {
            throw new InvalidOperationException($"{name} has no more cards to play.");
        }
        
        var rnd = new Random();
        var card = hand[rnd.Next(hand.Count)];
        hand.Remove(card);
        return card;
    }
    
    public void ExchangeHands(Player other)
    {
        if (!hasExchanged && !other.hasExchanged)
        {
            (hand, other.hand) = (other.hand, hand);

            hasExchanged = true;
            other.hasExchanged = true;

            Console.WriteLine($"{name} has exchanged hands with {other.name}.");
        }
    }
}