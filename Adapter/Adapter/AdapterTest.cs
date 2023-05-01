using System;
using NUnit.Framework;

namespace Adapter
{
    [TestFixture]
    public class AdapterTest
    {
        [Test]
        public void Test1()
        {
            Target target = new Adapter();
            
            var actual = target.Request();
            
            Assert.AreEqual("SpecificRequest", actual);
        }
    }
}