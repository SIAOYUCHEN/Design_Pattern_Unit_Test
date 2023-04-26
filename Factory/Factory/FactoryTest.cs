using System;
using NUnit.Framework;

namespace Factory
{
    [TestFixture]
    public class FactoryTest
    {
        [Test]
        public void Compare_Archer_Class_Name_Is_Same()
        {
            var trainer = new TrainArcher();

            var actual = trainer.Training().GetTypeName();
            
            Assert.AreEqual("Archer", actual);
        }
        
        [Test]
        public void Compare_Warrior_Class_Name_Is_Same()
        {
            var trainer = new TrainWarrior();

            var actual = trainer.Training().GetTypeName();
            
            Assert.AreEqual("Warrior", actual);
        }
    }
}