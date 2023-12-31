using System.Collections;

namespace ConsoleApp1;

public class Hand : IEnumerable<Card>
{
    private readonly List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        if (cards.Count >= 13)
        {
            throw new InvalidOperationException("The hand's size must not exceed 13.");
        }
        cards.Add(card);
    }

    public Card Get(int index)
    {
        return cards[index];
    }

    public Card Show(int index)
    {
        var card = cards[index];
        cards.RemoveAt(index);
        return card;
    }

    public int Size
    {
        get { return cards.Count; }
    }

    public IEnumerator<Card> GetEnumerator()
    {
        return cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}