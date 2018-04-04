using System;

namespace CustomListSorter
{
    class StartUp
    {
        static void Main()
        {
            CustomList<string> list = new CustomList<string>();
            

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                switch (command)
                {
                    case "Add":
                        list.Add(tokens[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(tokens[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(tokens[1]));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Sort":
                    Sorter.Sort(list);
                        break;
                    case "Print":
                        Print(list);
                        break;
                }
            }
        }

        private static void Print(CustomList<string> list)
        {
            foreach (var item in list.Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
