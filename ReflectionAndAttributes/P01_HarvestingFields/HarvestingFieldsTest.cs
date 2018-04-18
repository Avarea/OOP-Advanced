using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic); ;

            IEnumerable<FieldInfo> sorted = null;

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "public":
                        sorted = fields.Where(f => f.IsPublic);
                        break;
                    case "private":
                        sorted = fields.Where(f => f.IsPrivate);
                        break;
                    case "protected":
                        sorted = fields.Where(f => f.IsFamily);
                        break;
                    case "all":
                        sorted = fields;
                        break;
                }
                foreach (var field in sorted)
                {
                    var mod = field.Attributes.ToString().ToLower();

                    if (field.Attributes == FieldAttributes.Family)
                    {
                        mod = "protected";
                    }
                    Console.WriteLine($"{mod} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
