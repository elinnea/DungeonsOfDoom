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
            if (rnd.Next(0,101) < 100) 
            {
                Inventory.Add(Item.GenerateItem());
            }
        }
        
        public static Monster GenerateMonster()
        {
            switch (rnd.Next(0,3))
            {
                case 0:
                    return new Heffaklump();
                case 1:
                    return new Toucan();
                case 2:
                    return new RubberDuck();
                default:
                    break;
            }
        }
    }
}
