using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingInventory
    {
        private Inventory bag;
        private Item Hat;
        private Item Sword;
        
        [SetUp]
        public void SetUp()
        {
            bag = new Inventory();
            Hat = new Item(new string[] { "hat" }, "Ancient Hat", "This Belongs to the Great Pirate");
            Sword = new Item(new string[] { "sword" }, "a bronze sword", "The Mighty Sword yielded by a hero");
            bag.Put(Hat);
            bag.Put(Sword);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(bag.HasItem("hat"));
            Assert.IsTrue(bag.HasItem("SWORd"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(bag.HasItem("Ice"));
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.AreEqual(Sword, bag.Fetch("Sword"));
            Assert.IsTrue(bag.HasItem("sword"));
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.AreEqual(Sword, bag.Take("sword"));
            Assert.IsFalse(bag.HasItem("sword"));
        }

        [Test]
        public void TestItemList()
        {
            Assert.AreEqual("Ancient Hat(hat)\n\ta bronze sword(sword)\n\t",bag.ItemList);

        }
    }
}
