using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class RubberDuck : Monster
    {
        //static Random rnd = new Random();
        public RubberDuck() : base("Rupert", 'M', 10, 6)
        {
            messages = new string[3];
            messages[0] = "{0} the Rubber Duck squirts water at {1}! {2} lose {3} hp.";
            messages[1] = "{0} the Rubber Duck floats into {1}! {2} lose {3} hp.";
            messages[2] = "{0} the Rubber Duck pecks at {1}! {2} lose {3} hp.";

        }

        public override string Attack(Organism opponent)
        {
            string attackString = "";
            opponent.Health -= Strength;
            if (rnd.Next(0,100) % 2 == 0)
            {
            }
            return attackString;
        }

    }
}
