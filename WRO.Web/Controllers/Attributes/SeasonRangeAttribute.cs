using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Controllers.Attributes;

public class SeasonRangeAttribute : ValidationAttribute
{
    private readonly int _min;
    private readonly int _max;

    public SeasonRangeAttribute()
    {
        _min = 2023;
        _max = DateTime.Now.Year;
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        if (value is int val)
        {
            return _min <= val && val <= _max;
        }

        throw new ArgumentException("Argument is not a valid numeric type");
    }

    public override string FormatErrorMessage(string name)
    {
        return $"Value must be between {_min} and {_max}";
    }
}
