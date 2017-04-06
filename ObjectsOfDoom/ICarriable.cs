using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsOfDoom
{
    public interface ICarriable
    {
        int Weight { get;}
        string PickUp(Organism organism);
        int Power { get; set; }
    }
}
