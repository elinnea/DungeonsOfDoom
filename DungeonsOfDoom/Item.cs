using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject
    {
        static Random rnd = new Random();
        public Item(string name, char icon, int weight, int power) : base(name, icon)
        {
            Weight = weight;
            Power = power;
        }
        public int Power { get; set; }
        public int Weight { get; set; }
        public string Type { get; protected set; }

        public static Item GenerateItem()
        {
            Item item;
            if (rnd.Next(0, 30) % 3 == 0)
                return item = new Weapon("Sword", '?', rnd.Next(2, 7), rnd.Next(2, 6), "weapon");
            else
                return item = new Consumable("Apple", '?', 1, rnd.Next(5, 21), "consumable");
        }
    }
}
