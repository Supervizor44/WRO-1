using Microsoft.Extensions.Localization;
using WRO.Web.Helpers;

namespace WRO.Web.Localizer;

public class JsonStringLocalizer : IStringLocalizer
{
    private readonly Dictionary<string, string> _localizedStrings;

    public JsonStringLocalizer(string name, string resourcePath)
    {
        _localizedStrings = JsonHelper.Load<Dictionary<string, string>>(name, resourcePath) ?? throw new ArgumentNullException();
    }

    public LocalizedString this[string name] 
        => new(name, _localizedStrings.ContainsKey(name) && _localizedStrings[name] != null
            ? _localizedStrings[name] : name);

    public LocalizedString this[string name, params object[] arguments] 
        => new(name, _localizedStrings.ContainsKey(name) && _localizedStrings[name] != null 
            ? string.Format(_localizedStrings[name], arguments) : name);

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return _localizedStrings.Select(x => new LocalizedString(x.Key, x.Value ?? ""));
    }
}
