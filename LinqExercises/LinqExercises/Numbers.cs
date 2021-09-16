using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercises
{
    public static class Numbers
    {
        public static IEnumerable<int> AllNumbers()
        {
            int currentNumber = 0;
            while (true)
            {
                yield return currentNumber;
                if (currentNumber < int.MaxValue)
                {
                    currentNumber++;
                }
                else
                {
                    currentNumber = 0;
                }
            }
        }
    }
}
