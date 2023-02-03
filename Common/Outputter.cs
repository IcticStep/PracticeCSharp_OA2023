namespace Common;

public static class Outputter
{
    public static void ShowCollection(IEnumerable<string> array)
    {
        foreach (var word in array)
            Console.Write(word+" ");
        Console.WriteLine("\b");
    }
}