using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Direction
    {
        private string _name;
        private string _description;
        
        public Direction(string name, string desc)
        {
            _name = name;
            _description = desc;
        }
        
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
    }
}
