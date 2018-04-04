using System;

class StartUp
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            var input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}

