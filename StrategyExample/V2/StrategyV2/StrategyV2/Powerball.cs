namespace StrategyV2;

public class Powerball : IAttackType
{
    public void Attack(Hero attacker, Hero attacked)
    {
        attacked.Damage(500);
    }
}