namespace StrategyV2;

public class Waterball : IAttackType
{
    public void Attack(Hero attacker, Hero attacked)
    {
        attacked.Damage((int) (attacker.GetHp() * 0.5));
    }
}