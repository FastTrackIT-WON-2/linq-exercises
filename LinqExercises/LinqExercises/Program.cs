using System;
using System.Linq;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void Sample1_SelectEvenNumbers()
        {
            /* SQL-like syntax: 
            var query = from number in Numbers.AllNumbers()
                        where number % 2 == 0
                        select number;
            */

            var query = Numbers.AllNumbers()
                               .Where(number => number % 2 == 0);

            Console.Write("How many even numbers to display?=");
            int n = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            foreach (int evenNumber in query)
            {
                Console.Write($"{evenNumber}, ");
                i++;
                if (i >= n)
                {
                    break;
                }
            }
        }
    }
}
