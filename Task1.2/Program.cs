using Common;
using System.Text.RegularExpressions;

namespace Task1_2;

public static class Program
{
    private const string ExampleText = "Порушення академічної доброчесності під час виконання контрольних завдань призведе до";
    private static readonly char[] _searchLetters = { 'а', 'о' } ;

    public static void Main()
    {
        Outputter.Init();

        Console.WriteLine($"Початковий текст: {ExampleText}");

        Console.WriteLine($"Кількість літер у тексті:");
        foreach (var letter in _searchLetters)
            Console.WriteLine($"\t{_searchLetters}: {CountLettersAmount(ExampleText, letter)} шт.");
    }

    private static int CountLettersAmount(string text, char letter) =>
        new Regex(letter.ToString(), RegexOptions.IgnoreCase)
            .Matches(text)
            .Count;
}