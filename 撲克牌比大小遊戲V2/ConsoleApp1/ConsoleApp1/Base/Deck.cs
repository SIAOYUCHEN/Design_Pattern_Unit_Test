namespace ConsoleApp1.Base;

public class Deck<TCard>
{
    private readonly Stack<TCard> cardStack = new Stack<TCard>();

    public void Push(TCard card)
    {
        cardStack.Push(card);
    }

    public TCard Draw()
    {
        if (cardStack.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty.");
        }
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
            (cards[k], cards[n]) = (cards[n], cards[k]);
        }
        foreach (var card in cards)
        {
            cardStack.Push(card);
        }
    }

    public int Size()
    {
        return cardStack.Count;
    }

    public bool IsEmpty()
    {
        return cardStack.Count == 0;
    }

    public void Push(Deck<TCard> deck)
    {
        foreach (var card in deck.cardStack)
        {
            cardStack.Push(card);
        }
    }

    public void Clear()
    {
        cardStack.Clear();
    }
}