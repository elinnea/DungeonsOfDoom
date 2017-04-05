using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        public static int Randomize(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max + 1);
        }
    }
}
