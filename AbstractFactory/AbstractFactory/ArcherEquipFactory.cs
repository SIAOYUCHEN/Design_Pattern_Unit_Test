namespace AbstractFactory
{
    public class ArcherEquipFactory
    {
        public Weapon ProductWeapon() {
            Bow product = new Bow();
            product.SetAttack(100);
            product.SetRange(200);
            return product;
        }
        
        public Clothes ProductArmor() {
            Leather product = new Leather();
            product.SetDefence(300);
            return product;        
        }
    }
}