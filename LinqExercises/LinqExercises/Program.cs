using System;
using System.Linq;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var query = from person in PersonsDatabase.AllPersons()
                        where person.Age > 14 && person.LastName.StartsWith("M")
                        select person;
            */

            var query = PersonsDatabase.AllPersons()
                            .Where(person => person.Age > 14 && person.LastName.StartsWith("M"));

            foreach (var person in PersonsDatabase.AllPersons())
            {
                person.Print();
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Query results");
            Console.WriteLine("--------------------------------");

            foreach (var person in query)
            {
                person.Print();
            }
        }

        private static void FilterOperator_Where_PersonsOver14StartingWithM()
        {
            /*
            var query = from person in PersonsDatabase.AllPersons()
                        where person.Age > 14 && person.LastName.StartsWith("M")
                        select person;
            */

            var query = PersonsDatabase.AllPersons()
                            .Where(person => person.Age > 14 && person.LastName.StartsWith("M"));

            foreach (var person in PersonsDatabase.AllPersons())
            {
                person.Print();
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Query results");
            Console.WriteLine("--------------------------------");

            foreach (var person in query)
            {
                person.Print();
            }
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
