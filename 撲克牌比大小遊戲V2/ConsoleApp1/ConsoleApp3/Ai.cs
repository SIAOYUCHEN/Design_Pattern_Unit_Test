namespace ConsoleApp3;

public class Ai : Player
{
    private static readonly Random random = new Random();

    public override void NameSelf(int order)
    {
        SetName($"AI-{order}");
    }

    public override TurnMove TakeTurn(Card topCard)
    {
        int[] legalCardIndices = topCard == null ?
            Enumerable.Range(0, Hand.Count()).ToArray() :
            FilterLegalCardIndices(topCard);

        if (legalCardIndices.Length == 0)
        {
            return Pass(this);
        }
        int choice = legalCardIndices[random.Next(legalCardIndices.Length)];
        return Play(this, Hand.Play(choice));
    }

    private int[] FilterLegalCardIndices(Card topCard)
    {
        return Enumerable.Range(0, Hand.Count())
            .Where(i => Hand.Get(i).Color == topCard.Color ||
                        Hand.Get(i).Number == topCard.Number).ToArray();
    }
}