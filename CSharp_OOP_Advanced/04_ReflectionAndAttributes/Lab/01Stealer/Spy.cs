using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder stringBuilder = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        var stringBuilder = new StringBuilder();

        var classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Public);

        foreach (FieldInfo field in classFields)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        var classPublicMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Public);

        var classNonPublicMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        var stringBuilder = new StringBuilder();
        Type classType = Type.GetType(investigatedClass);

        var classPrivateMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic);

        stringBuilder.AppendLine($"All Private Methods of Class: {investigatedClass}");
        stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classPrivateMethods)
        {
            stringBuilder.AppendLine($"{method.Name}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        var stringBuilder = new StringBuilder();
        Type classType = Type.GetType(investigatedClass);

        var classPrivateMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var method in classPrivateMethods)
        {
            if (method.Name.StartsWith("get"))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
        }

        foreach (var method in classPrivateMethods)
        {
            if (method.Name.StartsWith("set"))
            {
                stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault()?.ParameterType}");
            }
        }

        return stringBuilder.ToString().Trim();
    }
}