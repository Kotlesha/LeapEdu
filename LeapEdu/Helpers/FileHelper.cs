namespace LeapEdu.Helpers;

internal static class FileHelper
{
    internal static async Task<string> ReadAllTextAsync(string filePath)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }
}
