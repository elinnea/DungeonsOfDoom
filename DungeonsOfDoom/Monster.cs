using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : Organism
    {
        static Random rnd = new Random();

        public Monster(string name, char icon, int health, int strength) : base(name, icon, health, strength) 
        {
            if (rnd.Next(0,101) < 10) 
            {
                Inventory.Add(Item.GenerateItem());
            }
        }

       

        public static Monster GenerateMonster()
        {
            //REFLECTION

            return new Monster("Monster", 'M', 10, rnd.Next(1, 10));
        }
    }
}
