﻿using System;
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
    }
}
