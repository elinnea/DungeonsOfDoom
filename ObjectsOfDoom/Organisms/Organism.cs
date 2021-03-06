﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsOfDoom
{
    public abstract class Organism : GameObject
    {
        public Organism(string name, char icon, int health, int strength, int weight, int power) : base(name, icon, power)
        {
            Health = health;
            Strength = strength;
            Weight = weight;
            Inventory = new List<ICarriable>();
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public List<ICarriable> Inventory { get; set; }
        public bool IsAlive { get { return Health > 0; } }
        public abstract string Attack(Organism opponent);

    }
}
