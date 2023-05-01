using System;
using NUnit.Framework;

namespace Templete
{
    [TestFixture]
    public class TempleteTest
    {
        [Test]
        public void Test1()
        {
            AbstractClass aA = new ConcreteClassA();
            
            var actual = aA.TemplateMethod();

            Assert.AreEqual("ConcreteClassAPrimitiveOperation1ConcreteClassAPrimitiveOperation2", actual);
            
            AbstractClass bB = new ConcreteClassB();
            
            actual = bB.TemplateMethod();
            
            Assert.AreEqual("ConcreteClassBPrimitiveOperation1ConcreteClassBPrimitiveOperation2", actual);
        }
    }
}