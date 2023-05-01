using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingLookCommand
    {
        private Player p;
        private LookCommand see;
        private Item Gem;
        private Bag b1;        

        [SetUp]
        public void Setup()
        {
            p = new Player("Luffy", "PirateKing");
            see = new LookCommand();
            Gem = new Item(new string[]{"gem"},"a gem", "a shiny red gem");
            b1 = new Bag(new string[] { "bag" }, "a bag", "I am a Backpack");

            p.Inventory.Put(Gem);
        }


        [Test]
        public void NewTestLookAtPlayersLocation()
        {
            Locations Swin = new Locations("Swinburne", "The Best");
            p.Location = Swin;

            //I am popping an Item in the player's location to check if the description is correct
            p.Location.Inventory.Put(Gem);
            Assert.AreEqual(p.Locate("room").FullDescription, see.Execute(p, new string[] { "look" }));

            //p.Locate("room").FullDescription == "You are in Swinburne, The Best. You can see: a gem\n\t"
        }

        [Test]
        public void NewTestLookAtGeminPlayersLocation()
        {
            Locations Swin = new Locations("Swinburne", "The Best");
            p.Location = Swin;

            // For this to be successful I need Locations to inherit from IHaveInventory
            p.Inventory.Take("Gem");
            p.Location.Inventory.Put(Gem);
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","room" });
            Assert.AreEqual(Gem.FullDescription, result);
        }


        [Test]
        public void TestLookAtMe()
        {
            string result = see.Execute(p, new string[] { "look", "at", "inventory" });
            Assert.AreEqual(p.FullDescription, result);
        }

        [Test]
        public void TestLookAtGem()
        {
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","inventory" });
            string result2 = see.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(Gem.FullDescription, result);
            Assert.AreEqual(Gem.FullDescription, result2);
        }

        [Test]
        public void TestLookAtUnk()
        {
            p.Inventory.Take("gem");
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","inventory"});
            Assert.AreEqual("I can't find the gem", result);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","inventory" });
            Assert.AreEqual(Gem.FullDescription, result);
        }

        [Test]
        public void TestLookAtGeminBag()
        {
            p.Inventory.Put(b1);
            b1.Inventory.Put(Gem);
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","bag" });
            Assert.AreEqual(Gem.FullDescription, result);
        }

        [Test]
        public void TestLookAtGeminNoBag()
        {
            b1.Inventory.Put(Gem);
            string result = see.Execute(p, new string[] { "look", "at", "gem","in","bag"});
            Assert.AreEqual("I can't find the bag", result);
        }

        [Test]
        public void TestLookAtNoGeminBag()
        {
            p.Inventory.Put(b1);

            string result = see.Execute(p, new string[] { "look", "at", "gem","in","bag" });
            Assert.AreEqual("I can't find the gem", result);
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I don't know how to look like that", see.Execute(p, new string[] { "Hello" }));
        }
    }
}
