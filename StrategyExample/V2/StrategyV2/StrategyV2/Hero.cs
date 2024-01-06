namespace StrategyV2;

public class Hero
{
    private int hp = 500;
    private readonly string name;
    private readonly IAttackType attackType;

    public Hero(string name, IAttackType attackType)
    {
        this.name = name;
        this.attackType = attackType;
    }

    public void Attack(Hero hero)
    {
        attackType.Attack(this, hero);
    }

    public void Damage(int damage)
    {
        SetHp(GetHp() - damage);
        Console.WriteLine($"英雄 {name} 受到了 {damage} 點傷害，生命值剩下 {hp}。");
    }

    public bool IsDead()
    {
        return hp <= 0;
    }

    public string GetName()
    {
        return name;
    }

    public void SetHp(int hp)
    {
        this.hp = Math.Max(0, hp);
    }

    public int GetHp()
    {
        return hp;
    }
}