using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Item
    {
        public Item(string name, int weight, string type)
        {
            Name = name;
            Weight = weight;
            Type = type;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
