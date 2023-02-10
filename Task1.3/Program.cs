using Common;
using System.Text.RegularExpressions;

namespace Task1_3;

public static class Program
{
    private const string ExampleText = "Some, english, words, kind, yellow, fight, night, four, umbrella, rainbow, magnify.";
    private const int CharacterLimit = 8;
    
    public static void Main()
    {
        Outputter.Init();
        Console.WriteLine($"Початковий текст:\n{ExampleText}\n");

        var wordsInLimit = GetWordsShorterThan(ExampleText, CharacterLimit);
        var shortestWords = GetAllShortestWords(wordsInLimit);
        
        Console.WriteLine($"Найкоротші слова, які містять від 1 до {CharacterLimit} букв:");
        Outputter.ShowCollection(shortestWords);
    }

    private static IEnumerable<string> GetWordsShorterThan(string text, int characterLimit) =>
        new Regex($@"\b\w{{1,{characterLimit}}}\b")
            .Matches(text)
            .Select(result => result.Value);

    private static IEnumerable<string> GetAllShortestWords(IEnumerable<string> words) =>
        words
            .OrderBy(word => word.Length)
            .TakeWhile(word => word.Length == words.First().Length);
}