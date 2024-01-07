namespace ConsoleApp2;

public class Deck : ConsoleApp1.Base.Deck<Card>
{
    public static Deck Standard52Cards()
    {
        Deck deck = new Deck();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                if (rank != Rank.R2) // Assuming Rank.R2 is used as a placeholder for a 2-rank card
                {
                    deck.Push(new Card(suit, rank));
                }
            }
        }
        return deck;
    }
}