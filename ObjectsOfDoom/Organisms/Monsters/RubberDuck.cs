﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ObjectsOfDoom
{
    public class RubberDuck : Monster
    {
        //static Random rnd = new Random();
        public RubberDuck() : base("Rupert the Rubber Duck", 'M', RandomUtils.Number(15,26), RandomUtils.Number(5,11), RandomUtils.Number(1,2), 0)
        {
            messages = new string[3];
            messages[0] = "{0} squirts water at {1}! {2} lose {3} hp. ";
            messages[1] = "{0} floats into {1}! {2} lose {3} hp. ";
            messages[2] = "{0} pecks at {1}! {2} lose {3} hp. ";

        }

        public override string Attack(Organism opponent)
        {
            string attackString = "";
            opponent.Health -= Strength;
            switch(RandomUtils.Number(0,3))
            {
                case 0:
                    attackString = String.Format($"{messages[0]}", Name, opponent.Name, opponent.Name, Strength);
                    break;
                case 1:
                    attackString = String.Format($"{messages[1]}", Name, opponent.Name, opponent.Name, Strength/2);
                    break;
                case 2:
                    attackString = String.Format($"{messages[2]}", Name, opponent.Name, opponent.Name, Strength);
                    break;

            }
            return attackString + "\n";
        }

    }
}
