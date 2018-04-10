using BashSoft.Contracts;

namespace BashSoft
{
    using System;

    public class InputReader : IReader
    {
        private IInterpreter interpreter;
        private const string endCommand = "quit";

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}>");
            string input = "";


            while (input != endCommand)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = input.Trim();
                input = Console.ReadLine();
                interpreter.InterpretComands(input);
            }
        }
    }
}
