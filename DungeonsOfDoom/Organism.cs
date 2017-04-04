using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Organism : GameObject
    {
        public Organism(string name, char icon, int health, int attack) : base(name, icon)
        {
            Health = health;
            Attack = attack;
            Inventory = new List<Item>();
        }

        public int Health { get; set; }
        public int Attack { get; set; }
        public List<Item> Inventory { get; set; }
        public bool IsAlive { get { return Health > 0; } }
    }
}
