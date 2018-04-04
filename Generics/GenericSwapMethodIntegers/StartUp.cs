using System;
using System.Collections.Generic;

namespace GenericSwapMethodIntegers
{
    class StartUp
    {
        static void Main()
        {
            var listOfInts = new List<Box<int>>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                listOfInts.Add(box);

            }
            var nums = Console.ReadLine()?.Split();
            int position1 = int.Parse(nums[0]);
            int position2 = int.Parse(nums[1]);

            Swap(listOfInts, position1, position2);

            listOfInts.ForEach(Console.WriteLine);
        }

        private static void Swap<T>(List<T> listOfStrings, int position1, int position2)
        {
            T temp = listOfStrings[position1];
            listOfStrings[position1] = listOfStrings[position2];
            listOfStrings[position2] = temp;
        }
    }
}
