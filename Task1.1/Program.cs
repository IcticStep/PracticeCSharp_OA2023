namespace Task1_1;

public static class Program
{
    public static void Main()
    {
        const string exampleText = "Порушення академічної доброчесності під час виконання контрольних завдань призведе до";
        const int lastWordsCount = 5;
        
        var array = exampleText.Split(" ");
        Console.WriteLine($"Використаний текст:\n{exampleText}\n");

        var lastWordsCharactersAmount = SumLastWordsCharacters(array, lastWordsCount);
        Console.WriteLine($"Кількість букв у {lastWordsCount} останніх словах:\n{lastWordsCharactersAmount}.");
    }

    private static int SumLastWordsCharacters(IEnumerable<string> collection, int lastWordsCount) => 
        collection
            .TakeLast(lastWordsCount)
            .Select(text => text.Length)
            .Sum();
}