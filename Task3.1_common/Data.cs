namespace Task3_1_common;

public static class Data
{
    public static readonly List<string> List1 = new() { "каучук", "нейлон", "паролон", "капрон" };
    public static readonly List<string> List2 = new() { "залізо", "олово", "свинець", "мідь" };
    
    private const string FileNamePrefix = "file";
    private const string FileExtension = ".txt";

    public static string GetFileName(int index) => FileNamePrefix + index + FileExtension;
}