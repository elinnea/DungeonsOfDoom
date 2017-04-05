using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class RubberDuck : Monster
    {
        public RubberDuck() : base("Rupert the", 'M', 10, 4)
        {

        }

        public override string Attack(Organism opponent)
        {
            return $"{Name} Rubber Duck squirts water at {opponent.Name}! {opponent.Name} lose {Strength} hp.";
        }

    }
}
