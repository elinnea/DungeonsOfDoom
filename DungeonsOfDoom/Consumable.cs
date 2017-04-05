using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Consumable : Item
    {
        public Consumable(string name, char icon, int weight, int power) : base(name, icon, weight, power)
        {
        }

        public override string PickUpItem(Organism organism)
        {
            organism.Health += Power;
            return $"{organism.Name} ate an {Name} and gained {Power} health.";
        }

        public override string UseItem(Organism user)
        {
            user.Health += Power;
            return $"Item {Name} was consumed. {user.Name} gained {Power} health. ";
        }
    }
}
