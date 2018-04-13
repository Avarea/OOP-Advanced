using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class StartUp
    {
        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            SortedSet<Person> sorted = new SortedSet<Person>();
            SortedSet<Person> hash = new SortedSet<Person>();


            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()?.Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
