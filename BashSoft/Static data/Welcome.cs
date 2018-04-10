namespace BashSoft.Static_data
{
    using System;

    public static class Welcome
    {

        public static void Message()
        {
            string message = $"Hello {Environment.UserName}!"; //and happy new year!

            int leftOffSet = (Console.WindowWidth / 2) - 10;
            int topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(message);

            Console.ResetColor();

            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
