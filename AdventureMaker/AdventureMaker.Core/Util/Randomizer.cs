using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureMaker.Core.Util
{
    public static class Randomizer
    {
        public static Random rand = new Random();

        public static int RollDices(int number, int sides)
        {
            int result = 0;

            for (int i = 0; i < number; i++)
            {
                result += rand.Next(0, sides + 1);
            }

            return result;
        }

    }
}
