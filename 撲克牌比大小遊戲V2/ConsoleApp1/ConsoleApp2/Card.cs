namespace ConsoleApp2;

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
        if (Rank == other.Rank)
        {
            return Suit - other.Suit;
        }
        return Rank - other.Rank;
    }

    public override string ToString()
    {
        // Assuming that you want to use the same symbols for suits as in the Java version
        char suitSymbol = Suit switch
        {
            Suit.Spade => '♠',
            Suit.Heart => '♥',
            Suit.Diamond => '♦',
            Suit.Club => '♣',
            _ => throw new ArgumentOutOfRangeException(nameof(Suit))
        };
        
        string rankRepresentation = Rank switch
        {
            Rank.R2 => "2", Rank.R3 => "3", Rank.R4 => "4", Rank.R5 => "5",
            Rank.R6 => "6", Rank.R7 => "7", Rank.R8 => "8", Rank.R9 => "9",
            Rank.R10 => "10", Rank.J => "J", Rank.Q => "Q", Rank.K => "K",
            Rank.A => "A", _ => throw new ArgumentOutOfRangeException(nameof(Rank))
        };

        return $"{suitSymbol}{rankRepresentation}";
    }
}

public enum Suit
{
    Club = 1, Diamond = 2, Heart = 3, Spade = 4
}

public enum Rank
{
    R2 = 2, R3 = 3, R4 = 4, R5 = 5, R6 = 6,
    R7 = 7, R8 = 8, R9 = 9, R10 = 10,
    J = 11, Q = 12, K = 13, A = 14
}