namespace StrategyV1;

public class Game
{
    private readonly List<Hero> heroes;

    public Game(Hero hero1, Hero hero2)
    {
        heroes = new List<Hero> { hero1, hero2 };
    }

    public void Start()
    {
        NextTurn();
    }

    private void NextTurn()
    {
        Hero attacker = heroes[0];
        Hero attacked = heroes[1];
        attacker.Attack(attacked);

        // 交换攻击者和被攻击者
        SwapHeroes();

        if (attacked.IsDead())
        {
            Console.WriteLine($"英雄 {attacked.Name} 死亡！{attacker.Name} 獲勝！");
        }
        else
        {
            NextTurn();
        }
    }

    private void SwapHeroes()
    {
        (heroes[0], heroes[1]) = (heroes[1], heroes[0]);
    }
}