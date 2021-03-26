using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Instance | BindingFlags.Public 
                | BindingFlags.NonPublic | BindingFlags.Static);
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in classFields.Where(x => fieldsNames.Contains(x.Name)))
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields
                (BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (FieldInfo field in classFields)
                stringBuilder.AppendLine($"{field.Name} must be private!");
            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
                stringBuilder.AppendLine($"{method.Name} have to be private!");

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in classNonPublicMethods)
                stringBuilder.AppendLine(method.Name);

            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
                stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

            return stringBuilder.ToString().Trim();
        }
    }
}
