namespace ConsoleApp1;

public class Deck
{
    private readonly Stack<Card> cardStack = new Stack<Card>();

    public static Deck Standard52Cards()
    {
        Deck deck = new Deck();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                deck.Push(new Card(suit, rank));
            }
        }
        return deck;
    }

    public void Push(Card card)
    {
        cardStack.Push(card);
    }

    public Card Draw()
    {
        return cardStack.Pop();
    }

    public void Shuffle()
    {
        var cards = cardStack.ToArray();
        cardStack.Clear();
        Random rng = new Random();
        int n = cards.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }

        foreach (var card in cards)
        {
            cardStack.Push(card);
        }
    }

    public int Size
    {
        get { return cardStack.Count; }
    }
}
