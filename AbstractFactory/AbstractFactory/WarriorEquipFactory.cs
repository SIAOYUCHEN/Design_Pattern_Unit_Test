namespace AbstractFactory
{
    public class WarriorEquipFactory
    {
        public Weapon ProductWeapon() {
            LongSword product = new LongSword();
            product.SetAttack(10);
            product.SetRange(20);
            return product;
        }
        
        public Clothes ProductArmor() {
            Armor product = new Armor();
            product.SetDefence(30);
            return product;        
        }
    }
}