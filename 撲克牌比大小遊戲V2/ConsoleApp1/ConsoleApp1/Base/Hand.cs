using System.Collections;

namespace ConsoleApp1.Base;

public class Hand<TCard> : IEnumerable<TCard>
{
    private readonly List<TCard> cards = new List<TCard>();

    public void AddCard(TCard card)
    {
        cards.Add(card);
    }

    public TCard Get(int index)
    {
        return cards[index];
    }

    public TCard Play(int index)
    {
        TCard card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public int Size()
    {
        return cards.Count;
    }

    public IEnumerator<TCard> GetEnumerator()
    {
        return cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool IsEmpty()
    {
        return !cards.Any();
    }

    public IEnumerable<TCard> Stream()
    {
        // In C#, the equivalent of Java's Stream is IEnumerable, which is returned by LINQ's methods
        return cards.AsEnumerable();
    }

    public List<TCard> AsList()
    {
        return new List<TCard>(cards);
    }
}