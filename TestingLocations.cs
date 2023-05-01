using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Swin_Adventure;

namespace TestingSwinAdventure
{
    public class TestingLocations
    {
        private Locations _location;
        private Item item;

        [SetUp]
        public void Setup()
        {
            _location = new Locations("space", "Black Hole");
            item = new Item(new string[] { "hat" }, "a hat", "a cool object.");
            _location.Inventory.Put(item);
        }

        [Test]
        public void TestLocationsisIdentifiable()
        {
            Assert.IsTrue(_location.AreYou("room"));
        }

        [Test]
        public void TestLocationsLocatesItems()
        {
            Assert.AreEqual(item, _location.Locate("hat"));
        }

        [Test]
        public void TestLocationsLocatesItself()
        {
            Assert.AreEqual(_location, _location.Locate("room"));
        }

        [Test]
        public void TestLocationsFullDescription()
        {
            Assert.AreEqual("You are in space, Black Hole. You can see: a hat(hat)\n\t", _location.FullDescription);
        }

        [Test]
        public void TestLocationsLocatesNothing()
        {
            Assert.AreEqual(null, _location.Locate("stick"));
        }
    }
}
