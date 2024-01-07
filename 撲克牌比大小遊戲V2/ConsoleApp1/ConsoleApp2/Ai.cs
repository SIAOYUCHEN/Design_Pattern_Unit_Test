namespace ConsoleApp2;

// public class AI<TCard> : Player<TCard>
// {
//     private static readonly Random random = new Random();
//     private Showdown showdown; // Assuming Showdown is a class or interface you have defined elsewhere
//
//     public override void NameSelf(int order)
//     {
//         SetName($"AI-{order}");
//     }
//
//     protected override TCard TakeTurn()
//     {
//         var handSize = GetHand().Size();
//         if (handSize == 1)
//         {
//             return GetHand().Get(0);
//         }
//         return GetHand().Play(random.Next(handSize));
//     }
//
//     public void SetShowdown(Showdown showdown)
//     {
//         this.showdown = showdown;
//     }
// }