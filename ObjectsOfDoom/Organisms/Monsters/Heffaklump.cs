﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ObjectsOfDoom
{
    public class Heffaklump :Monster
    {
        public Heffaklump() :base ("Hedvig Heffaklump", 'M', 20, 5, RandomUtils.Number(5, 10), 0)
        {
           
        }

        public override string Attack(Organism opponent)
        {
            opponent.Health -= Strength;
            return $"{Name} sat on {opponent.Name}! {opponent.Name} lose {Strength} hp\n"; 
        }

    }
}
