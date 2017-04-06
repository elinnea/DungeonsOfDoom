using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface ICarriable
    {
        int Weight { get; }
        string PickUp(Organism organism);
        int Power { get; set; }
    }
}
