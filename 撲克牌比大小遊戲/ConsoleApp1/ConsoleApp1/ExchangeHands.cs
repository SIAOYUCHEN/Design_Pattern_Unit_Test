namespace ConsoleApp1;

public class ExchangeHands
{
    private int countdown = 3;
    private readonly Player exchanger;
    private readonly Player exchangee;

    public ExchangeHands(Player exchanger, Player exchangee)
    {
        this.exchanger = exchanger ?? throw new ArgumentNullException(nameof(exchanger));
        this.exchangee = exchangee ?? throw new ArgumentNullException(nameof(exchangee));
        Exchange();
    }

    private void Exchange()
    {
        Hand hand = exchanger.GetHand();
        exchanger.SetHand(exchangee.GetHand());
        exchangee.SetHand(hand);
        Console.WriteLine($"You have exchanged your hand with the player {exchangee.GetName()}.");
    }

    public void Countdown()
    {
        countdown--;
        if (countdown == 0)
        {
            Exchange(); // exchange back when it's dead
        }
    }
}