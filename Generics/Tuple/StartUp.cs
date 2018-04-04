using System;

class StartUp
{
    static void Main()
    {
        var firstInput = Console.ReadLine()?.Split();
        var firstTuple = new Tuple<string,string>(firstInput[0] + " " + firstInput[1], firstInput[2]);
        PrintTuple(firstTuple);

        var secondInput = Console.ReadLine()?.Split();
        var secondTuple = new Tuple<string,int>(secondInput[0], int.Parse(secondInput[1]));
        PrintTuple(secondTuple);

        var thirdInput = Console.ReadLine()?.Split();
        var thirdTuple = new Tuple<int,double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));
        PrintTuple(thirdTuple);
    }

    public static void PrintTuple<T1, T2>(Tuple<T1, T2> tuple)
    {
        Console.WriteLine($"{tuple.FirstItem} -> {tuple.SecondItem}");
    }
}

