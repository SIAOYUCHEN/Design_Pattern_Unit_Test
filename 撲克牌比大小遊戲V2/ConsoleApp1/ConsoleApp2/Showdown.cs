using ConsoleApp1.Base;

namespace ConsoleApp2;

// public class Showdown : CardGame<Player, Card>
// {
//     public static readonly int NumOfRounds = 13;
//     private readonly List<ShowCard> showCards = new List<ShowCard>();
//
//     public Showdown(Deck<Card> deck, List<Player> players) : base(deck, players)
//     {
//     }
//
//     protected override void TakeTurn(Player player)
//     {
//         Console.WriteLine($"It's {player.Name}'s turn.");
//         Card card = player.TakeTurn();
//         showCards.Add(new ShowCard(player, card));
//     }
//
//     protected override void OnRoundEnd()
//     {
//         ShowdownRound();
//         showCards.Clear();
//     }
//
//     private void ShowdownRound()
//     {
//         PrintShowCards();
//         ShowCard winningShowCard = showCards.Max();
//         Player winner = winningShowCard.Player;
//         winner.GainPoint();
//         Console.WriteLine($"{winner.Name} wins this round.");
//     }
//
//     private void PrintShowCards()
//     {
//         Console.Write("Show cards: ");
//         Console.WriteLine(string.Join(" ", showCards.Select(sc => sc.Card.ToString())));
//     }
//
//     protected override bool IsGameOver(int currentRound)
//     {
//         return currentRound >= NumOfRounds;
//     }
//
//     protected override Player GetWinner()
//     {
//         return players.OrderByDescending(p => p.Point).First();
//     }
//
//     protected override int GetInitialHandSize()
//     {
//         // Assuming that the initial hand size is the same as the number of rounds
//         return NumOfRounds;
//     }
// }