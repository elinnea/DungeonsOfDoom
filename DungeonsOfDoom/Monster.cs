using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : Organism
    {
        protected string[] messages;
        public Monster(string name, char icon, int health, int strength) : base(name, icon, health, strength) 
        {
            if (RandomUtils.Randomize(0,100) < 10) 
            {
                Item.GenerateItem().PickUpItem(this);
            }
        }
        
        public static Monster GenerateMonster()
        {
            switch (RandomUtils.Randomize(0,2))
            {
                case 0:
                    return new Heffaklump();
                case 1:
                    return new Toucan();
                case 2:
                    return new RubberDuck();
            }
            return null;
        }
    }
}
