using System.Text;

namespace Task1_2;

public static class Program
{
    public static void Main()
    {
        const string exampleTest = "РечЕнНя, Де Всі СлоВа ПочиНаюТсья З ВеликОї БуКВи І Ще Є ДоДаТКові.";
        
        Console.WriteLine($"Використаний текст:\n{exampleTest}\"");
        var proceeded = ProceedTextDowncasing(exampleTest);
        Console.WriteLine($"Текст після приведення до нижнього регістру всіх літер, окрім першої:\n{proceeded}");
    }

    private static string ProceedTextDowncasing(string text)
    {
        var words = text.Split(" ");
        var result = new StringBuilder();
        
        foreach (var word in words)
            result.Append(DowncaseWordExceptOfFirstCharacter(word) + " ");

        result.Remove(result.Length - 1, 1);
        return result.ToString();
    }

    private static string DowncaseWordExceptOfFirstCharacter(string word)
    {
        if (word.Length <= 1)
            return word;
        return word.First() + string.Concat(word.ToLower().Skip(1));
    }
}