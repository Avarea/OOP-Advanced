using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class StartUp
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedByName = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new PersonAgeComparer());


            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()?.Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name,age);
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, sortedByName));
            Console.WriteLine(string.Join(Environment.NewLine, sortedByAge));
        }
    }
}
