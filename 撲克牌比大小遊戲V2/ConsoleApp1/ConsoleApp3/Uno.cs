using ConsoleApp1.Base;

namespace ConsoleApp3;

public class Uno : CardGame<Player, Card>
{
    private Deck<Card> discards = new Deck<Card>();
    private Card topCard;

    public Uno(Deck<Card> deck, List<Player> players) : base(deck, players)
    {
    }

    protected override int GetInitialHandSize()
    {
        return 5;
    }

    protected override void OnGameBegins()
    {
        topCard = Deck.Draw();
    }

    protected override void TakeTurn(Player player)
    {
        TurnMove turnMove = player.TakeTurn(topCard);
        if (turnMove.Pass)
        {
            Pass(player);
        }
        else
        {
            if (IsValidMove(turnMove))
            {
                PlayCard(player, turnMove);
            }
            else
            {
                turnMove.Undo();
            }
        }
    }

    private bool IsValidMove(TurnMove turnMove)
    {
        Card card = turnMove.Card;
        return topCard.Color == card.Color ||
               topCard.Number == card.Number;
    }

    private void Pass(Player player)
    {
        Console.WriteLine($"Player {player.GetName()} pass so he has to draw a card from the deck.");
        ReshuffleDeckIfEmpty();
        player.AddHandCard(Deck.Draw());
    }

    private void PlayCard(Player player, TurnMove turnMove)
    {
        if (topCard != null)
        {
            Discards.Push(topCard);
        }
        topCard = turnMove.Card;
        Console.WriteLine($"Player {player.GetName()} plays a {topCard}.");
    }

    private void ReshuffleDeckIfEmpty()
    {
        if (Deck.IsEmpty())
        {
            Console.WriteLine("The deck is empty, reshuffling the deck.");
            Deck.Push(Discards);
            Discards.Clear();
            Deck.Shuffle();
        }
    }

    protected override bool IsGameOver(int currentRound)
    {
        return TurnPlayer.Hand.IsEmpty();
    }

    protected override Player GetWinner()
    {
        return TurnPlayer;
    }
}