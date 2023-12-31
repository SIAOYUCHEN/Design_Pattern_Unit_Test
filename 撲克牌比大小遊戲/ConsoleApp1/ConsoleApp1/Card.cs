namespace ConsoleApp1;

public class Card : IComparable<Card>
{
    public Suit Suit { get; }
    public Rank Rank { get; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int CompareTo(Card other)
    {
        if (other == null) return 1;

        if (Rank == other.Rank)
        {
            return Suit.CompareTo(other.Suit);
        }
        return Rank.CompareTo(other.Rank);
    }

    public override string ToString()
    {
        return $"{Suit}{Rank}";
    }
}

public enum Suit
{
    SPADE = '♠',
    HEART = '♥',
    DIAMOND = '♦',
    CLUB = '♣'
}

public enum Rank
{
    R2 = 2, R3, R4, R5, R6, R7, R8, R9, R10, J = 11, Q, K, A = 14
}