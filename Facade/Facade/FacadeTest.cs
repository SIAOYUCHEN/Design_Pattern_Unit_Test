using System;
using NUnit.Framework;

namespace Facade
{
    [TestFixture]
    public class FacadeTest
    {
        [Test]
        public void Test1()
        {
            Facade facade = new Facade();
            
            var actual = facade.MethodA();

            Assert.AreEqual("SystemOneSystemTwoSystemFour", actual);

            actual = facade.MethodB();
            
            Assert.AreEqual("SystemTwoSystemThree", actual);
            
            Assert.True(true);
        }
    }
}