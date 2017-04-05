using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public Weapon(string name, char icon, int weight, int power) : base(name, icon, weight, power)
        {

        }


        public override string UseItem(Organism user)
        {
            Power -= 1;
            return $"{user.Name} used item {Name}. The weapon is worn and loses 1 strength.";
        }
    }
}
