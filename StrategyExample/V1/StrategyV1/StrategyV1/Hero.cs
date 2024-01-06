namespace StrategyV1;

public class Hero
{
    private int hp = 500;
    private readonly string name;
    private readonly string attackType;

    public Hero(string name, string attackType)
    {
        this.name = name;
        this.attackType = attackType;
    }

    public void Attack(Hero hero)
    {
        switch (attackType)
        {
            case "Waterball":
                hero.Damage((int)(hp * 0.5));
                break;
            case "Fireball":
                for (int i = 0; i < 3; i++)
                {
                    hero.Damage(50);
                }
                break;
            case "Earth":
                for (int i = 0; i < 10; i++)
                {
                    hero.Damage(20);
                }
                break;
        }
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        Console.WriteLine($"英雄 {name} 受到了 {damage} 點傷害，生命值剩下 {hp}。");
    }

    public bool IsDead()
    {
        return hp <= 0;
    }

    public string Name
    {
        get { return name; }
    }

    private int Hp
    {
        get { return hp; }
        set { hp = Math.Max(0, value); }
    }
}