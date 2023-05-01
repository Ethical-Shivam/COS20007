using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        
        public string Name
        {
            get ;
        }
        
    }
}
