using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            
            return false;

        }

        public void Put(Item id)
        {
            _items.Add(id);
        }

        public Item Take(string id)
        {
            foreach (Item item in _items)
            {
                if (Fetch(id) == item)
                {
                    _items.Remove(item);
                    return item;
                }
            }

            return null;

        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                string result = null;
                foreach (Item itm in _items)
                {
                    result = result + $"{itm.ShortDescription}"+"\n\t" ;
                }
                return result;
            }
        }
    }
}
