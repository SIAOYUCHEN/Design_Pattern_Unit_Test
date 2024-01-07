namespace ConsoleApp1.Base;

public abstract class Player<TCard>
{
    protected Hand<TCard> hand = new Hand<TCard>();
    protected string name;

    public abstract void NameSelf(int order);

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void AddHandCard(TCard card)
    {
        this.hand.AddCard(card);
    }

    public Hand<TCard> GetHand()
    {
        return hand;
    }
}