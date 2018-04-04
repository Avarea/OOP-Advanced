using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main()
        {
            List<Box<string>> listOfStrings = new List<Box<string>>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                listOfStrings.Add(box);
            }

            var element = Console.ReadLine();
            var compareBox = new Box<string>(element);
            int result = CompareElementsWithGivenElement(listOfStrings, compareBox);

            Console.WriteLine(result);
        }
        public static int CompareElementsWithGivenElement<T>(List<T> list, T item)
        {
            int count = 0;
            foreach (T box in list)
            {
                var firstBox = box as Box<string>;
                var secondBox = item as Box<string>;
                int result = firstBox.CompareTo(secondBox);
                if (result > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
