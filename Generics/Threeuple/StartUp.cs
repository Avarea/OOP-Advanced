using System;

namespace Threeuple
{
    class StartUp
    {
        static void Main()
        {
            var firstInput = Console.ReadLine()?.Split();
            var firstTuple = new Threeuple<string, string, string>(firstInput[0] + " " + firstInput[1], firstInput[2], firstInput[3]);
            PrintTuple(firstTuple);

            var secondInput = Console.ReadLine()?.Split();
            bool isDrunk = secondInput[2] == "drunk";
            var secondTuple = new Threeuple<string, int,bool>(secondInput[0], int.Parse(secondInput[1]), isDrunk);
            PrintTuple(secondTuple);

            var thirdInput = Console.ReadLine()?.Split();
            var thirdTuple = new Threeuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);
            PrintTuple(thirdTuple);
        }

        public static void PrintTuple<T1, T2, T3>(Threeuple<T1, T2, T3> threeuple)
        {
            Console.WriteLine($"{threeuple.FirstItem} -> {threeuple.SecondItem} -> {threeuple.ThirdItem}");
        }
    }
}
