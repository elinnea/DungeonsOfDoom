using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Toucan : Monster
    {
        
        public Toucan() : base("Tony Toucan", 'M', rnd.Next(25,36), rnd.Next(12,20))
        {
           
        }
        

    }
}
