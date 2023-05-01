using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingPlayer
    {
        private Player Sai;
        private Item Hat;
        private Item Sword;

        [SetUp]
        public void SetUp()
        {
            Sai = new Player("Sai", "The Hero");
            Hat = new Item(new string[] { "hat" }, "Ancient Hat", "This Belongs to the Great Pirate");
            Sword = new Item(new string[] { "sword" }, "a bronze sword", "The Mighty Sword yielded by a hero");
            Sai.Inventory.Put(Hat);
        }

        [Test]
        public void NewTestPlayerHasLocation()
        {
            Locations Swin = new Locations("Swinburne", "The Best");
            Sai.Location = Swin;

            Assert.AreEqual("Swinburne", Sai.Location.Name);
        }

        [Test]
        public void NewTestPlayerLocatesItemsInLocations()
        {
            Locations Swin = new Locations("Swinburne", "The Best");
            Sai.Location = Swin;

            Sai.Location.Inventory.Put(Sword);
                        
            Assert.AreEqual(Sword, Sai.Locate("sword"));

        }

        [Test]
         public void NewTestPlayerLocatesItsLocation()
        {
            Locations Swin = new Locations("LateLab", "Open 24/7");
            Sai.Location = Swin;
            Assert.AreEqual("You are in LateLab, Open 24/7. You can see: ", Sai.Locate("room").FullDescription);            
        }

        [Test]
        public void TestPlayerisIdentifiable()
        {
            Assert.IsTrue(Sai.AreYou("me"));
            Assert.IsTrue(Sai.AreYou("inventory"));
            Assert.IsTrue(Sai.AreYou("inv"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.AreEqual(Hat,Sai.Locate("hat"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(Sai, Sai.Locate("me"));
            Assert.AreEqual(Sai, Sai.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocatesNothiing()
        {
            Assert.AreEqual(null, Sai.Locate("Diamond"));
        }


        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.AreEqual("You are Sai The Hero. You are carrying:Ancient Hat(hat)\n\t", Sai.FullDescription);
        }
    }
}
