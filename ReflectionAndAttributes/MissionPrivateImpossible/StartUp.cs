﻿using System;

namespace MissionPrivateImpossible
{
    class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
