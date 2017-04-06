using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
    {
        static Random r = new Random();
        public static int Number(int min, int max)
        {
            return r.Next(min, max + 1);
        }

        public static bool Percent(int percent)
        {
            return Number(0,100) < percent;
        }
    }
}
