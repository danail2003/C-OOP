using System;
using System.Reflection;
using System.Text;
using System.Linq;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] fields)
    {
        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        StringBuilder stringBuilder = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        stringBuilder.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (var field in fieldsInfo.Where(x => fields.Contains(x.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string nameOfClass)
    {
        Type classType = Type.GetType(nameOfClass);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var field in fieldsInfo)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        foreach (var field in privateMethods.Where(x=>x.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{field.Name} have to be public!");
        }

        foreach (var field in publicMethods.Where(x=>x.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{field.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string nameOfClass)
    {
        Type type = Type.GetType(nameOfClass);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"All Private Methods of Class: {nameOfClass}");
        stringBuilder.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var field in methods)
        {
            stringBuilder.AppendLine($"{field.Name}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string nameOfClass)
    {
        Type type = Type.GetType(nameOfClass);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var method in methods.Where(x=>x.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x=>x.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().Trim();
    }
}
