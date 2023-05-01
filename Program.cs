using System;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player;
            Item item1;
            Item item2;
            Item item3;
            Bag bag;
            Locations Swinburne;

            Console.WriteLine();
            Console.WriteLine("Enter Your Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Your Description?");
            string Description = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Hi {Name + ", " + Description}");
            Console.WriteLine();
            
            player = new Player(Name, Description);
            Swinburne = new Locations("Swinburne", "Educational Institute");

            player.Location = Swinburne;

            item1 = new Item(new string[]{"hat"}, "a hat", "a cool object");
            item2 = new Item(new string[] { "stick" }, "a stick", "a simple weapon");

            player.Inventory.Put(item1);
            player.Inventory.Put(item2);

            bag = new Bag(new string[] {"bag" }, "backpack", "I am a backpack");

            player.Inventory.Put(bag);

            item3 = new Item(new string[] { "diamond" }, "a diamond", "a shiny object");
                        
            bag.Inventory.Put(item3);

            Console.WriteLine(player.ShortDescription);
            Console.WriteLine(player.Location.ShortDescription);
            Console.WriteLine(item1.ShortDescription);
            Console.WriteLine(item2.ShortDescription);
            Console.WriteLine(bag.ShortDescription);
            Console.WriteLine(item3.ShortDescription);

            Console.WriteLine();
            
            string answer= "";
            LookCommand look = new LookCommand();


            // As long as answer string is not equal to no the loop will go on
            while (answer != "no")
            {
                Console.WriteLine("Do you want to look at anything? ");
                answer = Console.ReadLine();

                //The loop will terminate if the answer is no
                
                if (answer == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Bye Bye");
                    continue;
                }

                //Split is used to breakdown the answer string into an array. It is broken down at the white spaces.

                string ok = look.Execute(player, answer.Split());
                
                Console.WriteLine();
                Console.WriteLine(ok);
                Console.WriteLine();

            }
        }
    }
}
