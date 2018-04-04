using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class StartUp
    {
        static void Main()
        {
            List<Box<double>> listOfDoubles = new List<Box<double>>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);
                listOfDoubles.Add(box);
            }

            var element = double.Parse(Console.ReadLine());
            var compareBox = new Box<double>(element);
            int result = CompareElementsWithGivenElement(listOfDoubles, compareBox);

            Console.WriteLine(result);
        }
        public static int CompareElementsWithGivenElement<T>(List<T> list, T item)
        {
            int count = 0;
            foreach (T box in list)
            {
                var firstBox = box as Box<double>;
                var secondBox = item as Box<double>;
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
