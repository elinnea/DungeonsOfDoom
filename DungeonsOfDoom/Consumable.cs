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
            organism.Inventory.Add(this);
            return $"Item {Name} with a power of {Power} was added to backpack. ";
        }

        public override string UseItem(Organism user)
        {
            user.Health += Power;
            //user.Inventory.Remove(this);
            return $"Ate an {Name} and gained {Power} health.";
        }
    }
}
