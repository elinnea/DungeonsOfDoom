using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    static class RandomUtils
    {
        static Random r;
        static RandomUtils() { r = new Random(); }
        public static int Randomize(int min, int max)
        {
            int temp;
            temp = r.Next(min, max + 1);
            return temp;
        }
    }
}
