namespace ConsoleApp1;

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        var ranks = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (var rank in ranks)
            {
                cards.Add(new Card(rank, suit));
            }
        }
    }

    public void Shuffle()
    {
        var rnd = new Random();
        cards = cards.OrderBy(card => rnd.Next()).ToList();
    }

    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            var card = cards.First();
            cards.RemoveAt(0);
            return card;
        }
        
        throw new InvalidOperationException("No more cards in the deck.");
    }
}