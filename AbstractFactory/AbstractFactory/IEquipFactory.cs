namespace AbstractFactory
{
    public interface IEquipFactory
    {
        Weapon ProductWeapon();
        
        Clothes ProductArmor();
    }
}