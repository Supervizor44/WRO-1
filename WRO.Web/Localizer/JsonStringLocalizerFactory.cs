using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Globalization;

namespace WRO.Web.Localizer;

public class JsonStringLocalizerFactory : IStringLocalizerFactory
{
    private readonly ConcurrentDictionary<string, IStringLocalizer> _localizers = new();
    private readonly string _resourcePath;

    public JsonStringLocalizerFactory(string resourcePath)
    {
        _resourcePath = resourcePath;
    }

    public IStringLocalizer Create(Type resourceSource)
    {
        string name = $"{resourceSource.Name}.{CultureInfo.CurrentCulture.Name[..2]}";
        return _localizers.GetOrAdd(name, new JsonStringLocalizer(name, _resourcePath));
    }
    
    /// <summary>I use this method slightly different</summary>
    /// <param name="baseName">example: Lang</param>
    /// <param name="location">example: az</param>
    public IStringLocalizer Create(string baseName, string location)
    {
        string name = $"{baseName}.{location}";
        return _localizers.GetOrAdd(name, new JsonStringLocalizer(name, _resourcePath));
    }

    public void Remove(string name) // example: Lang.az
    {
        _localizers.TryRemove(name, out _);
    }
}