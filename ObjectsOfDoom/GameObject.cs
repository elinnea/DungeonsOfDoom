using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsOfDoom
{
    public abstract class GameObject : ICarriable
    {
        public GameObject(string name, char icon, int power)
        {
            Name = name;
            Icon = icon;
            Power = power;
        }

        public string Name { get; private set; }
        public char Icon { get; private set; }

        public int Weight { get; set; }
        public int Power { get; set; }
        public abstract string PickUp(Organism organism);
    }
}
