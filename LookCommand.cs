using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand():base(new string[] {"look"})
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5 && text.Length == 1 && text[0] != "look")
            {
                return "I don't know how to look like that";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text.Length >1 && text[1] != "at")
            {
                return "What do you want to look at?";
            }

            IHaveInventory container = null;
            string thingId = null;

            if (text.Length == 5)
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }

                thingId = text[2];
                container = FetchContainer(p, text[4]);

                if (container == null)
                {
                    return $"I can't find the {text[4]}";
                }
            }
            else if (text.Length == 3 && text[1] == "at")
            {
                thingId = text[2];
                container = p;
            }
            else if(text.Length ==1 && text[0] == "look")
            {
                if(p.Location != null)
                {
                    thingId = "room";
                    container = p;
                }
                else
                {
                    return "You are nowhere";
                }
            }
            
            return LookAtIn(thingId, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            IHaveInventory container = p.Locate(containerId) as IHaveInventory;
            
            if (container == null)
            {
                return null;
            }
            else
            {
                return container;
            }
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return $"I can't find the {thingId}";
            }
            
            return container.Locate(thingId).FullDescription;
            
        }


    }

}
