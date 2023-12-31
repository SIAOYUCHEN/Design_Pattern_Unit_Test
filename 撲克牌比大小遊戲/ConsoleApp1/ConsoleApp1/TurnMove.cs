namespace ConsoleApp1;

public class TurnMove
{
    private readonly Player player;
    private readonly ExchangeHands? exchangeHands;
    private readonly Card showCard;

    public TurnMove(Player player, ExchangeHands? exchangeHands, Card showCard)
    {
        this.player = player ?? throw new ArgumentNullException(nameof(player));
        this.exchangeHands = exchangeHands;
        this.showCard = showCard ?? throw new ArgumentNullException(nameof(showCard));
    }

    public Player GetPlayer()
    {
        return player;
    }

    public ExchangeHands? GetExchangeHands()
    {
        return exchangeHands;
    }

    public Card GetShowCard()
    {
        return showCard;
    }
}