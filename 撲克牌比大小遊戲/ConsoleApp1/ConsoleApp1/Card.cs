namespace ConsoleApp1;

public class Card
{
    private string rank;
    private Suit suit;

    public Card(string rank, Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
    }
    
    public static bool operator >(Card a, Card b)
    {
        var rankOrder = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        if (a.rank == b.rank)
        {
            return a.suit > b.suit;
        }
        
        return rankOrder.IndexOf(a.rank) > rankOrder.IndexOf(b.rank);
    }

    public static bool operator <(Card a, Card b)
    {
        return b > a;
    }
}