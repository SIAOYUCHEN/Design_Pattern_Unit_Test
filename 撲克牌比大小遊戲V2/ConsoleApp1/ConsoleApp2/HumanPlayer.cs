using System.Text;

namespace ConsoleApp2;

// public class HumanPlayer : Player<Card> // Assuming that Player<Card> is an abstract class you have defined
// {
//     public override void NameSelf(int order)
//     {
//         Console.Write($"Input your name (P{order}): ");
//         string name = Console.ReadLine();
//         if (string.IsNullOrEmpty(name))
//         {
//             NameSelf(order);
//         }
//         else
//         {
//             SetName(name);
//         }
//     }
//
//     protected override Card TakeTurn()
//     {
//         PrintCardSelections();
//         try
//         {
//             int choice = int.Parse(Console.ReadLine());
//             if (choice < 0 || choice >= GetHand().Size())
//             {
//                 return TakeTurn();
//             }
//             return GetHand().Play(choice);
//         }
//         catch (FormatException)
//         {
//             // If the input was not a valid integer, prompt the user again.
//             Console.WriteLine("Invalid input. Please enter a number.");
//             return TakeTurn();
//         }
//     }
//
//     private void PrintCardSelections()
//     {
//         Console.WriteLine("Select the card to play (by number): ");
//         StringBuilder numbers = new StringBuilder();
//         StringBuilder cards = new StringBuilder();
//         for (int i = 0; i < GetHand().Size(); i++)
//         {
//             string cardRepresentation = GetHand().Get(i).ToString();
//             numbers.Append($"{i}".PadRight(cardRepresentation.Length)).Append(" ");
//             cards.Append(cardRepresentation).Append(" ");
//         }
//
//         Console.WriteLine(numbers.ToString().TrimEnd());
//         Console.WriteLine(cards.ToString().TrimEnd());
//     }
// }