using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Controllers.Attributes;

public class MaxAllowedFileSizeAttribute : ValidationAttribute
{
    private readonly long _maxSize;

    /// <param name="maxSize">In kbytes</param>
    public MaxAllowedFileSizeAttribute(long maxSize)
    {
        _maxSize = maxSize;
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return false;

        if (value is IFormFile file)
            return IsValidFormFile(file);

        if (value is IFormFileCollection files)
            return files.All(IsValidFormFile);

        throw new ArgumentException("Value type must be IFormFile or IFormFileCollection");
    }

    private bool IsValidFormFile(IFormFile file) => file.Length < _maxSize * 1024;

    public override string FormatErrorMessage(string name)
    {
        return $"Maximum allowed file size is {_maxSize} kbytes.";
    }
}
