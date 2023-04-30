using System;
using NUnit.Framework;

namespace Builder
{
    [TestFixture]
    public class BuilderTest
    {
        [Test]
        public void Test1()
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            var actual = p1.Show();

            Assert.AreEqual("PartAPartB", actual);

            director.Construct(b2);
            Product p2 = b2.GetResult();
            actual = p2.Show();
            
            Assert.AreEqual("PartXPartY", actual);
        }
    }
}