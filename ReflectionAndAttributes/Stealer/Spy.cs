using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        foreach (var field in fieldsInfo.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}

