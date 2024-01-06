// See https://aka.ms/new-console-template for more information

using StrategyV2;

class Program
{
    static void Main(string[] args)
    {
        Hero hero1 = new Hero("水之球", new Powerball());
        Hero hero2 = new Hero("大潘", new Waterball());
        Game game = new Game(hero1, hero2);
        game.Start();
    }
}