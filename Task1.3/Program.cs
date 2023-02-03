using System.Text.RegularExpressions;

namespace Task1_3;

public static class Program
{
    public static void Main()
    {
        const string exampleText = "Some, english, words, lockjaw, flyblow, hacksaw, bucksaw.";
        const string targetEnding = "w";

        Console.WriteLine($"Використаний текст:\n{exampleText}\n");
        Console.WriteLine($"Слова, що закінчуються на \"{targetEnding}\":");

        GetWordsWithEnding(exampleText, targetEnding)
            .ToList()
            .ForEach(Console.WriteLine);
    }

    public static IEnumerable<string> GetWordsWithEnding(string text, string ending) =>
        new Regex($@"\b\w*{ending}\b")
            .Matches(text)
            .Select(result => result.Value);
}