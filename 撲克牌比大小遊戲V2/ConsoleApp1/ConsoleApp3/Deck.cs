namespace ConsoleApp3;

public class Deck : ConsoleApp1.Base.Deck<Card>
{
    public static Deck StandardUnoDeck()
    {
        Deck deck = new Deck();
        foreach (int num in Enumerable.Range(0, 10)) // 0 to 9 inclusive
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                deck.Push(new Card(num, color));
            }
        }
        return deck;
    }
}