using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Path : IdentifiableObject
    {
        private string _name;
        private string _description;
        private Locations _direction;
        private Locations _destination;

        public Path(string name, string desc,string[] ids, Locations direction, Locations destination) : base(ids)
        {
            _name = name;
            _description = desc;
            _direction = direction;
            _destination = destination;
        }

        public void Move(Player p)
        {
            p.Location = Destination;

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

        public Locations Direction
        {
            get
            {
                return _direction;
            }
        }

        public Locations Destination
        {
            get
            {
                return _destination;
            }
        }

        public string FullDescription
        {
            get
            {
                return $"You are heading {Direction} to reach {Destination} on the {Name}.";
            }
        }
    }
}
