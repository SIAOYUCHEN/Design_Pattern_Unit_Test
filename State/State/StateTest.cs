using System;
using NUnit.Framework;

namespace State
{
    [TestFixture]
    public class StateTest
    {
        [Test]
        public void Test1()
        {
            Context c = new Context(new ConcreteStateA());
            c.Request();
            c.Request();
            c.Request();
            c.Request();
            
            Assert.True(true);
        }
    }
}