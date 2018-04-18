using System;

namespace HighQualityMistakes
{
    class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
