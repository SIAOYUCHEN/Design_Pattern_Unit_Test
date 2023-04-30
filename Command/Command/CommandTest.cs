using System;
using NUnit.Framework;

namespace Command
{
    [TestFixture]
    public class CommandTest
    {
        [Test]
        public void Test1()
        {
            Light light = new Light();

            Command turnOn = new TurnOn(light);
            Command brighter = new Brighter(light);
            Command darker = new Daker(light);

            Invoker invoker = new Invoker();

            invoker.AddCommand(turnOn);
            invoker.AddCommand(brighter);
            invoker.AddCommand(brighter);
            invoker.AddCommand(brighter);
            invoker.AddCommand(darker);

            invoker.Execute();
            
            Assert.True(true);
        }
    }
}