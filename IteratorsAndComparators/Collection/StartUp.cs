using System;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split();

            ListyIterator<string> listyIterator = new ListyIterator<string>(tokens.Skip(1).ToList());
            while (input != "END")
            {
                tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            listyIterator.PrintAll();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
