using System;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()?.Split(", ").Select(int.Parse).ToArray();

            Lake lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
