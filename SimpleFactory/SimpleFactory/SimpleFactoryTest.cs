using System;
using NUnit.Framework;

namespace SimpleFactory
{
    [TestFixture]
    public class SimpleFactoryTest
    {
        private TrainAdventure _trainer = new TrainAdventure();

        [Test]
        public void Compare_Archer_Class_Name_Is_Same()
        {
            var actual = _trainer.Training("archer").GetTypeName();

            Assert.AreEqual("Archer", actual);
        }
        
        [Test]
        public void Compare_Warrior_Class_Name_Is_Same()
        {
            var actual = _trainer.Training("warrior").GetTypeName();

            Assert.AreEqual("Warrior", actual);
        }
    }
}