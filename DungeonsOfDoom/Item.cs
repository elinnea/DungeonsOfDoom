﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject, ICarriable
    {
        static Random rnd = new Random();
        public Item(string name, char icon, int weight, int power) : base(name, icon)
        {
            Weight = weight;
            Power = power;
        }
        public int Power { get; protected set; }
        public int Weight { get; private set; }

        public abstract string PickUpItem(Organism organism);

        public static Item GenerateItem()
        {
            Item item;
            if (RandomUtils.Percent(30))
            {
                item = new Weapon("Sword", '?', RandomUtils.Number(2, 7), RandomUtils.Number(2, 6));
            }
            else
                item = new Consumable("Apple", '?', 1, RandomUtils.Number(5, 21));
            return item;
        }

        public override string ToString()
        {
            return $"{Name}, power: {Power}, weight: {Weight}";
        }

        public abstract string UseItem(Organism user);
    }
}
