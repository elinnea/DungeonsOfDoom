using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player
    {
        
        public Player(int health, int x, int y, int maxWeight) //Constructor sätter klassens state
        {
            Health = health;
            X = x;
            Y = y;
            Inventory = new List<Item>();
            Weight = 0;
            MaxWeight = maxWeight;
        }

        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Inventory { get; set; }
        public int Weight { get; set; }
        public int MaxWeight { get; set; }
    }
}
