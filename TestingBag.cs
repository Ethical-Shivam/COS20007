using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingBag
    {
        private Bag b1;
        private Item itm;

        [SetUp]
        public void Setup()
        {
            b1 = new Bag(new string[] { "Baggage","It's me" }, "BackPack", "I am a backpack");
            itm = new Item(new string[] { "stik" }, "Weapon", "This is a Item");
            b1.Inventory.Put(itm);

        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.AreEqual(itm,b1.Locate(itm.FirstId));
            Assert.AreEqual(itm, b1.Locate("stik"));
            Assert.IsTrue(b1 != null);
            Assert.AreEqual("In the BackPack you can see:Weapon(stik)\n\t", b1.FullDescription);
        }

        [Test]
        public void TestBagLocatesitself()
        {
            Assert.AreEqual(b1, b1.Locate(b1.FirstId));
            Assert.AreEqual(b1, b1.Locate("Baggage"));
            Assert.AreEqual(b1, b1.Locate("It's me"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.AreEqual(null, b1.Locate("Ok Not Good"));
        }
        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the BackPack you can see:Weapon(stik)\n\t", b1.FullDescription);
        }

        [Test]
        public void TestBaginBag()
        {
            Bag b2 = new Bag(new string[] { "pouch" }, "Bag", "I am the second backpack");
            Item item = new Item(new string[] { "bat" }, "Bat", "This is a ball");

            b1.Inventory.Put(b2);
            b2.Inventory.Put(item);

            Assert.AreEqual(b2, b1.Locate("Pouch"));

            Assert.AreEqual(itm, b1.Locate("stik"));

            Assert.AreEqual(null, b1.Locate("bat"));
        }

    }
}
