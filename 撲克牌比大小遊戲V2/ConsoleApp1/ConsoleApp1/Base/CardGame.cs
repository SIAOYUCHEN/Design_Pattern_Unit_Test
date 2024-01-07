namespace ConsoleApp1.Base;

public abstract class CardGame<TPlayer, TCard>
    where TPlayer : Player<TCard>
{
    protected List<TPlayer> players;
    protected Deck<TCard> deck;
    protected TPlayer turnPlayer;
    protected int turn = 0;
    protected int round = 0;

    public CardGame(Deck<TCard> deck, List<TPlayer> players)
    {
        this.players = players;
        this.deck = deck;
    }

    public void Start()
    {
        NameThemselves();
        DrawHands();
        OnGameBegins();
        NextTurn();
    }

    protected virtual void OnGameBegins()
    {
        // hook
    }

    private void NameThemselves()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].NameSelf(i + 1);
        }
    }

    private void DrawHands()
    {
        int initialHandSize = GetInitialHandSize();
        for (int i = 0; i < initialHandSize; i++)
        {
            foreach (TPlayer player in players)
            {
                TCard card = deck.Draw();
                player.AddHandCard(card);
            }
        }
    }

    protected void NextTurn()
    {
        turnPlayer = players[turn % players.Count];
        TakeTurn(turnPlayer);
        turn++;
        if (turn % players.Count == 0)
        {
            round++;
            OnRoundEnd();
        }
        if (IsGameOver(round))
        {
            GameOver();
        }
        else
        {
            NextTurn();
        }
    }

    private void GameOver()
    {
        TPlayer winner = GetWinner();
        Console.WriteLine($"The winner is {winner.GetName()}.");
    }

    protected abstract int GetInitialHandSize();

    protected abstract void TakeTurn(TPlayer nextPlayer);

    protected virtual void OnRoundEnd() {}

    protected abstract bool IsGameOver(int currentRound);

    protected abstract TPlayer GetWinner();
}