﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class GameObject : ICarriable
    {
        public GameObject(string name, char icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get; private set; }
        public char Icon { get; private set; }

        public int Weight { get; set; }

        public abstract string PickUp(Organism organism);
    }
}
