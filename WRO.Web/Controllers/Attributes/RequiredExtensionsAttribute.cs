using System.ComponentModel.DataAnnotations;

namespace WRO.Web.Controllers.Attributes;

public class RequiredExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _permittedExtensions;

    public RequiredExtensionsAttribute(params string[] permittedExtensions)
    {
        _permittedExtensions = permittedExtensions;
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

    private bool IsValidFormFile(IFormFile file)
    {
        string ext = Path.GetExtension(file.FileName).ToLower();
        return _permittedExtensions.Contains(ext);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"File extension must be one of {string.Join(", ", _permittedExtensions)}";
    }
}
