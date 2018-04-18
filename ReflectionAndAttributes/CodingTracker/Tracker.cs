using System;
using System.Linq;
using System.Reflection;
using CodingTracker;

public class Tracker : Attribute
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(m => m.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }

            }
        }
    }
}

