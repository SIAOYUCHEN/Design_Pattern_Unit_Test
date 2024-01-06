// See https://aka.ms/new-console-template for more information

using StrategyV1;

class Program
{
    static void Main(string[] args)
    {
        Hero hero1 = new Hero("水之球", "Waterball");
        Hero hero2 = new Hero("大潘", "Fireball");
        Game game = new Game(hero1, hero2);
        game.Start();
    }
}