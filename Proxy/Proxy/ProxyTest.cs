using System;
using NUnit.Framework;

namespace Proxy
{
    [TestFixture]
    public class ProxyTest
    {
        [Test]
        public void Test1()
        {
            Proxy proxy = new Proxy();
            
            var actual = proxy.Request();

            Assert.AreEqual("RealSubjectRequest", actual);
        }
    }
}