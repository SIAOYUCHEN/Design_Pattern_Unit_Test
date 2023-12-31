namespace ConsoleApp1;

public abstract class Player
{
    protected int point;
    protected Shutdown shutdown;
    private string name;
    private Hand hand = new Hand();
    private ExchangeHands exchangeHands;

    public TurnMove TakeTurn()
    {
        var turnMove = new TurnMove(this, HasUsedExchangeHands() ? null : MakeExchangeHandsDecision(), ShowCard());
        if (turnMove.GetExchangeHands() != null)
        {
            SetExchangeHands(turnMove.GetExchangeHands());
        }
        GetExchangeHands()?.Countdown();
        return turnMove;
    }

    public abstract void NameSelf(int order);

    protected abstract ExchangeHands MakeExchangeHandsDecision();

    protected abstract Card ShowCard();

    public void SetShutdown(Shutdown shutdown)
    {
        this.shutdown = shutdown ?? throw new ArgumentNullException(nameof(shutdown));
    }

    public void AddHandCard(Card card)
    {
        hand.AddCard(card ?? throw new ArgumentNullException(nameof(card)));
    }

    public void SetName(string name)
    {
        this.name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void GainPoint()
    {
        point++;
    }

    public void SetExchangeHands(ExchangeHands exchangeHands)
    {
        this.exchangeHands = exchangeHands;
    }

    public bool HasUsedExchangeHands()
    {
        return exchangeHands != null;
    }

    public ExchangeHands GetExchangeHands()
    {
        return exchangeHands;
    }

    public Hand GetHand()
    {
        return hand;
    }

    public string GetName()
    {
        return name;
    }

    public void SetHand(Hand hand)
    {
        this.hand = hand ?? throw new ArgumentNullException(nameof(hand));
    }

    public int GetPoint()
    {
        return point;
    }
}