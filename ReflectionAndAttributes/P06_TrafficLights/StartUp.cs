using System;
using System.Collections.Generic;

namespace P06_TrafficLights
{
    class StartUp
    {
        static void Main()
        {
            string[] lightTokens = Console.ReadLine()?.Split();
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            foreach (var lightToken in lightTokens)
            {
                var isLight = Enum.TryParse(lightToken, out Light light);

                if (isLight)
                {
                    trafficLights.Add(new TrafficLight(light));
                }
            }

            string result = string.Empty;
            int numberOfInteractions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInteractions; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeLight();
                }
                result = string.Join(" ", trafficLights);
                Console.WriteLine(result);
            }
        }
    }
}
