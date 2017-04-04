using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Monster : Organism
    {
        public Monster(string name, char icon, int health, int attack) : base(name, icon, health, attack) 
        {
            Random rnd = new Random();
            if (rnd.Next(0,101) < 100) 
            {
                Inventory.Add(Item.GenerateItem());
            }
        }
    }
}
