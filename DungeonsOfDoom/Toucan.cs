using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Toucan : Monster
    {
        public Toucan() : base("Tony Toucan", 'M', RandomUtils.Number(25,35), RandomUtils.Number(12,19), RandomUtils.Number(2,3))
        {
            messages = new string[3];
            messages[0] = $"{Name} pecks at your eyes with his mighty beak, dealing {Strength} damage. ";
            messages[1] = $"{Name} flaps his wings at you, dealing {Strength} damage. ";
            messages[2] = $"{Name} fires a sharp feather to your heart, dealing {Strength} damage. ";

        }

        public override string Attack(Organism opponent)
        {
            opponent.Health -= Strength;
            return messages[RandomUtils.Number(0,2)] + "\n";
        }

    }
}
