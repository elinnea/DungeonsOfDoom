using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Consumable : Item, IConsumable
    {
        public Consumable(string name, char icon, int weight, int power) : base(name, icon, weight, power)
        {
        }

        public int HealthGain { get; set; }

        public override string PickUp(Organism organism)
        {
            organism.Inventory.Add(this);
            return $"Item {Name} with a power of {Power} was added to backpack. \n";
        }

        public override string UseItem(Organism user)
        {
            user.Health += Power;
            //user.Inventory.Remove(this);
            return $"Ate an {Name} and gained {Power} health. \n";
        }
    }
}
