using System;
using NUnit.Framework;

namespace Strategy
{
    [TestFixture]
    public class StrategyTest
    {
        private Adventurer _adventurer = new Adventurer();

        [Test]
        public void Compare_Normal_Attack_Is_Same()
        {
            _adventurer.ChoiceStrategy(new NormalAttack());

            var actual = _adventurer.Attack();

            Assert.AreEqual("NormalAttack", actual);
        }
        
        [Test]
        public void Compare_UseItem_Attack_Is_Same()
        {
            _adventurer.ChoiceStrategy(new UseItem());

            var actual = _adventurer.Attack();

            Assert.AreEqual("UseItem", actual);
        }
        
        [Test]
        public void Compare_UseSkill_Attack_Is_Same()
        {
            _adventurer.ChoiceStrategy(new UseSkill());

            var actual = _adventurer.Attack();

            Assert.AreEqual("UseSkill", actual);
        }
    }
}