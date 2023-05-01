using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Locations _locations;

        public Player(string name, string desc) : base(new string[] { "me", "inventory", "inv" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            if (_inventory.Fetch(id) != null)
            {
                return _inventory.Fetch(id);
            }
            if (_locations != null)
            {
                return _locations.Locate(id);
            }
            else
            {
                return null;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name} " + base.FullDescription + $". You are carrying:{_inventory.ItemList}"; ;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Locations Location
        {
            get
            {
                return _locations;
            }
            set
            {
                _locations = value;
            }
        }

        public void Move(Path path)
        {
            if (path.Direction != null)
            {
                _locations = path.Direction;
            }
        }

    }
}
