using System;
using System.Collections;
using System.Linq;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] indices = { 1, 2, 3};
            string[] names = { "name", "other" };

            var query = names.Zip(indices, (elem1, elem2) => $"{elem1}{elem2}");

            foreach (var element in query)
            {
                Console.Write($"{element}, ");
            }
        }

        private static void GrouppingOperator_GroupBy_WithOrderingOfGroups()
        {
            /*
            var query = from person in PersonsDatabase.AllPersons()
                        where person.Age >= 30
                        orderby person.DateOfBirth.Year ascending
                        group person by person.DateOfBirth.Year;

            // or with query continuation and order by groups

            var query = from person in PersonsDatabase.AllPersons()
                        where person.Age >= 30
                        group person by person.DateOfBirth.Year into groups
                        orderby groups.Key ascending
                        select groups;
            */

            var query = PersonsDatabase.AllPersons()
                .Where(person => person.Age >= 30)
                .GroupBy(person => person.DateOfBirth.Year)
                .OrderBy(group => group.Key);


            foreach (var person in PersonsDatabase.AllPersons())
            {
                person.Print();
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Query results");
            Console.WriteLine("--------------------------------");

            foreach (var group in query)
            {
                Console.WriteLine($"Year of birth: {group.Key}");
                foreach (var person in group)
                {
                    person.Print();
                }
            }
        }

        private static void SortOperator_OrderBy_ComposedOrderCondition()
        {
            /*
            var query = from person in PersonsDatabase.AllPersons()
                        where person.Age >= 20 && person.Age <= 40
                        orderby person.Age ascending, person.LastName descending
                        select person;
            */

            var query = PersonsDatabase.AllPersons()
                .Where(person => person.Age >= 20 && person.Age <= 40)
                .OrderBy(person => person.Age).ThenByDescending(person => person.LastName);

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

        private static void ProjectionOperator_SelectMany_TwoCollectionsWithResultsSelector()
        {
            int[] collection1 = { 1, 2, 3, 4 };
            int[] collection2 = { 3, 4, 5, 6, 7 };

            /*
            var query = from elem1 in collection1
                        from elem2 in collection2
                        where Math.Abs(elem1 - elem2) == 1
                        select new { Element1 = elem1, Element2 = elem2 };
            */

            var query = collection1
                .SelectMany(
                    elem1 => collection2,
                    (elem1, elem2) => new { Element1 = elem1, Element2 = elem2 })
                .Where(pair => Math.Abs(pair.Element1 - pair.Element2) == 1);

            foreach (var catesianElement in query)
            {
                Console.Write($"({catesianElement.Element1}, {catesianElement.Element2}); ");
            }
        }

        private static void ProjectionOperator_SelectMany_SingleCollection()
        {
            int[] collection = { 1, 2, 3, 4 };
            // I Want to obtain a collection like:
            // 1, 1, 1, 2, 4, 8, 3, 9, 27, ....

            /*
            var query = from number in collection
                        from powers in new[] { number, number * number, number * number * number }
                        select powers;
            */

            var query = collection
                .SelectMany(number => new[] { number, number * number, number * number * number });

            foreach (var element in query)
            {
                Console.Write($"{element}, ");
            }
        }

        private static void ProjectionOperator_Select_SimpleWithIndexes()
        {
            /*
            var query = from person in PersonsDatabase.AllPersons()
                        select person.FullName;
            */

            var query = PersonsDatabase.AllPersons()
                            .Select((person, index) => new { FullName = person.FullName, Index = index });

            foreach (var person in PersonsDatabase.AllPersons())
            {
                person.Print();
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Query results");
            Console.WriteLine("--------------------------------");

            foreach (var fullNameWithIndex in query)
            {
                Console.WriteLine($"{fullNameWithIndex.Index} - {fullNameWithIndex.FullName}");
            }
        }

        private static void FilterOperator_OfType_WithNonGenericCollections()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add("test");
            list.Add(new Person("firstname", "lastname", DateTime.Now.AddYears(-20), Gender.Male));

            var query = list.OfType<string>();

            foreach (string str in query)
            {
                Console.WriteLine(str);
            }
        }

        private static void FilterOperator_OfType_WithInheritance()
        {
            var query = PersonsDatabase.AllPersons().OfType<Student>();

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
