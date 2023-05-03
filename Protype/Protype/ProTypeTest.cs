using System;
using NUnit.Framework;

namespace Protype
{
    [TestFixture]
    public class ProTypeTest
    {
        [Test]
        public void Test1()
        {
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            var c1 = (ConcretePrototype1) p1.Clone();

            var actual = c1.Id;

            Assert.AreEqual("I", actual);
            
            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2) p2.Clone();
            
            actual = c2.Id;
            Assert.AreEqual("II", actual);
        }
    }
}