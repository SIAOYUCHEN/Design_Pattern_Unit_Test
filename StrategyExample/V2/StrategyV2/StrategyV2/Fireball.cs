namespace StrategyV2;

public class Fireball : IAttackType
{
    public void Attack(Hero attacker, Hero attacked)
    {
        for (int i = 0; i < 3; i++) {
            attacked.Damage(50);
        }
    }
}