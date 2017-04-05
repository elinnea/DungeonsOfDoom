using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Organism : GameObject
    {
        public Organism(string name, char icon, int health, int strength) : base(name, icon)
        {
            Health = health;
            Strength = strength;
            Inventory = new List<Item>();
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public List<Item> Inventory { get; private set; }
        public bool IsAlive { get { return Health > 0; } }

        public virtual string Attack(Organism opponent)
        {
            return $"The monster hits you for {Strength} hp";
        }

    }
}
