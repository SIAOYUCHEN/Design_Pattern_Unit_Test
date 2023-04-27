using System;
using NUnit.Framework;

namespace Decorator
{
    [TestFixture]
    public class DecoratorTest
    {
        [Test]
        public void Test1()
        {
            var applePhone = new ApplePhone();
            
            Decorator applePhoneWithSticker = new Sticker(applePhone);

            var actual = applePhoneWithSticker.Print();

            Assert.AreEqual("ApplePhone-AddSticker", actual);
            
            Decorator applePhoneWithAccessories = new Accessories(applePhone);

            actual = applePhoneWithAccessories.Print();
            
            Assert.AreEqual("ApplePhone-AddAccessories", actual);
            
            Sticker sticker = new Sticker(applePhone);
            
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            
            actual = applePhoneWithAccessoriesAndSticker.Print();
            
            Assert.AreEqual("ApplePhone-AddSticker-AddAccessories", actual);
        }
    }
}