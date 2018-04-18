using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] publicMethodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in fieldsInfo)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in privateMethodInfos.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethodInfos.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        foreach (var field in fieldsInfo.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string classToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        MethodInfo[] methodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {classToInvestigate}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in methodInfo)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}

