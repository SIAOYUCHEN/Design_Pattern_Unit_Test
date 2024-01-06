namespace StrategyV2;

public class Earth : IAttackType
{
    public void Attack(Hero attacker, Hero attacked)
    {
        for (int i = 0; i < 10; i++)
        {
            attacked.Damage(20);
        }
    }
}