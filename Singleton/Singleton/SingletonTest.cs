using System;
using NUnit.Framework;

namespace Singleton
{
    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void Same_Instance_Return_True()
        {
            Singleton instance1 = Singleton.GetInstance();
            
            Singleton instance2 = Singleton.GetInstance();

            Assert.True(instance1 != null);
            
            Assert.True(instance2 != null);
            
            Assert.AreEqual(instance1, instance2);
        }
    }
}