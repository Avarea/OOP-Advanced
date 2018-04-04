using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class StartUp
    {
        static void Main()
        {
            var listOfStrings = new List<string>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                listOfStrings.Add(box.ToString());
            }

            var nums = Console.ReadLine()?.Split();
            int position1 = int.Parse(nums[0]);
            int position2 = int.Parse(nums[1]);

            Swap(listOfStrings, position1, position2);

            listOfStrings.ForEach(Console.WriteLine);
        }

        private static void Swap<T>(List<T> listOfStrings, int position1, int position2)
        {
            T temp = listOfStrings[position1];
            listOfStrings[position1] = listOfStrings[position2];
            listOfStrings[position2] = temp;
        }
    }
}
