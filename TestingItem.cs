using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingItem
    {

        private Item item;

        [SetUp]
        public void SettingUp()
        {
            item = new Item(new string[] {"sword"}, "a bronze sword","The Mighty Sword yielded by a hero");
        }


        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsFalse(item.AreYou("AnythingElse"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("a bronze sword(sword)", item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("The Mighty Sword yielded by a hero", item.FullDescription);
        }
    }
}
