
namespace WRO.Web.Helpers;

public class FormFileHelper
{
    private readonly IWebHostEnvironment _environment;

    public FormFileHelper(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public void Upload(IFormFile file, string relativeDirectory, out string fileName, out string filePath)
    {
        string directory = Path.Combine(_environment.WebRootPath, relativeDirectory);
        Directory.CreateDirectory(directory);

        string destinationPath = Path.Combine(directory, fileName = GenerateName(file));

        using var stream = File.Create(destinationPath);
        file.CopyTo(stream);

        

        filePath = '\\' + Path.Combine(relativeDirectory, fileName);
    }

    public void Overwrite(IFormFile file, string relativePath)
    {
        using var stream = File.Create($"{_environment.WebRootPath}{relativePath}");
        file.CopyTo(stream);
    }

    public void Delete(string relativePath)
    {
        File.Delete($"{_environment.WebRootPath}{relativePath}");
    }

    static string GenerateName(IFormFile file)
    {
        return $"{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N")[..8]}{Path.GetExtension(file.FileName).ToLower()}";
    }
}
