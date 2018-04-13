using System;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main()
        {
            Stack<string> stack = new Stack<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Push")
                {
                    foreach (var element in tokens.Skip(1))
                    {
                        stack.Push(element);
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                input = Console.ReadLine();
            }

            PrintStackElements(stack);
            PrintStackElements(stack);
        }

        private static void PrintStackElements(Stack<string> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
