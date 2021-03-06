﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ObjectsOfDoom
{
    public abstract class Monster : Organism
    {
        protected string[] messages;
        public Monster(string name, char icon, int health, int strength, int weight, int power) : base(name, icon, health, strength, weight, power) 
        {
            if (RandomUtils.Percent(10)) 
            {
                Item.GenerateItem().PickUp(this);
            }
            MonsterCount++;
        }

        public override string ToString()
        {
            return $"{Name}, power: {Power}, weight: {Weight}";
        }

        public static int MonsterCount { get; set; }

        public override string PickUp(Organism organism)
        {
            organism.Weight += Weight;
            organism.Inventory.Add(this);
            return ($"Picked up {Name}\n");
        }

        public static Monster GenerateMonster()
        {
            switch (RandomUtils.Number(0,2))
            {
                case 0:
                    return new Heffaklump();
                case 1:
                    return new Toucan();
                case 2:
                    return new RubberDuck();
            }
            return null;
        }
    }
}
