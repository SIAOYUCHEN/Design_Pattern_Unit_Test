namespace ConsoleApp3;

public class TurnMove
{
    public Player Player { get; }
    public bool IsPass { get; }
    public Card Card { get; }

    private TurnMove(Player player, bool pass, Card card)
    {
        Player = player;
        IsPass = pass;
        Card = card;
    }

    public static TurnMove Pass(Player player)
    {
        return new TurnMove(player, true, null);
    }

    public static TurnMove Play(Player player, Card card)
    {
        return new TurnMove(player, false, card);
    }

    public void Undo()
    {
        Player.AddHandCard(Card);
    }
}