using System.Text;
using System.Text.Json;

namespace WRO.Web.Helpers;

public static class JsonHelper
{
    public static T? Load<T>(string name, string? relativeDirectory = null)
    {
        name = relativeDirectory is null ? name : Path.Combine(relativeDirectory, name);
        string json = File.ReadAllText($"{name}.json", Encoding.UTF8);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static IEnumerable<T> LoadCollection<T>(string name, string? relativeDirectory = null)
    {
        return Load<IEnumerable<T>>(name, relativeDirectory) ?? new HashSet<T>();
    }

    public static void Save<T>(T data, string name, string? relativeDirectory = null)
    {
        name = relativeDirectory is null ? name : Path.Combine(relativeDirectory, name);
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText($"{name}.json", json, Encoding.UTF8);
    }
}
