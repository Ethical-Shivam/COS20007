using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{

    public class Locations : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Locations(string name, string desc) : base(new string[] { "room","here" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in {Name}, {base.FullDescription}. You can see: {_inventory.ItemList}";
            }
        }
    }
}
