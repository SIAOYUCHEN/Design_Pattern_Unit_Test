using System;
using NUnit.Framework;

namespace AbstractFactory
{
    [TestFixture]
    public class AbstractFactoryTest
    {
        [Test]
        public void Compare_Archer_Diversity_Value_Is_Same()
        {
            var archerFactory = new ArcherEquipFactory();
            Clothes archerLeather = archerFactory.ProductArmor();
            Weapon archerBow = archerFactory.ProductWeapon();
            
            var leatherActual = archerLeather.GetDefence();
            var archerBowAttackActual = archerBow.GetAttack();
            var archerBowRangeActual = archerBow.GetRange();

            Assert.AreEqual(300, leatherActual);
            Assert.AreEqual(100, archerBowAttackActual);
            Assert.AreEqual(200, archerBowRangeActual);
        }
        
        [Test]
        public void Compare_Warrior_Diversity_Value_Is_Same()
        {
            var warriorEquipFactory = new WarriorEquipFactory();
            Clothes warriorArmor = warriorEquipFactory.ProductArmor();
            Weapon warriorSword = warriorEquipFactory.ProductWeapon();
            
            var armorActual = warriorArmor.GetDefence();
            var warriorSwordAttackActual = warriorSword.GetAttack();
            var warriorSwordRangeActual = warriorSword.GetRange();

            Assert.AreEqual(30, armorActual);
            Assert.AreEqual(10, warriorSwordAttackActual);
            Assert.AreEqual(20, warriorSwordRangeActual);
        }
    }
}