using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class Spy
{
    public string StealFieldInfo(string name, params string[] fieldNames)
    {
        Type classType = Type.GetType(name);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder result = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        result.AppendLine($"Class under investigation: {name}");

        foreach (FieldInfo field in classFields.Where(f => fieldNames.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");

        }

        return result.ToString().Trim();
    }
}
