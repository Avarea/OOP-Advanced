using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name,age,town);
                persons.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = persons[index];

            int matches = 0;
            foreach (var p in persons)
            {
                if (personToCompare.CompareTo(p) == 0)
                {
                    matches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {persons.Count - matches} {persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
