using Common;

namespace Task1_1;

public static class Program
{
    private const string ExampleText = "Порушення академічної доброчесності під час виконання контрольних завдань призведе до";

    public static void Main()
    {
        Outputter.Init();
        var array = ExampleText.Split(" ");
        Console.WriteLine($"Початковий текст(Масив B[10]):");
        Outputter.ShowCollection(array);

        var reversedArray = array.Reverse().ToArray();
        Console.WriteLine($"\nТекст в зворотньому порядку(Масив C[10]):");
        Outputter.ShowCollection(reversedArray);
    }
}