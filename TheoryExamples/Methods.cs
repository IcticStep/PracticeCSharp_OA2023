namespace TheoryExamples;

public static class MethodExample1
{
    public static void Main() => ShowAwesomeTextToUser();

    private static void ShowAwesomeTextToUser() 
        => Console.WriteLine("Here is some awesome text you might never seen before");
}

public static class MethodExample2
{
    public static void Main()
    {
        GetInput("Введіть скільки вам років: ", out var age);
        Console.WriteLine($"\nМи вас зрозуміли... З ваших слів, вам {age} років.");
    }

    private static void GetInput(in string message, out double input)
    {
        do
            Console.Write(message);
        while (!double.TryParse(Console.ReadLine(), out input)); 
    }
}

public static class MethodExample3
{
    public static void Main()
    {
        GetInput("Скільки у вас є яблук: ", out var age);
        var evaluation = EvaluateApplesAmount(in age);
        Console.WriteLine($"Ми оцінюємо ваш стратегічний запас як: {evaluation}.");
    }
    
    private static void GetInput(string message, out int input)
    {
        do
            Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out input)); 
    }

    private static string EvaluateApplesAmount(in int number) => number <= 2 ? "мало" : "поїсти хватить";
}

public static class MethodExample4
{
    public static void Main()
    {
        var allNumbersTogether = SumNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        Console.WriteLine($"Сума чисел від 1 до 10 включно: {allNumbersTogether}.");
    }

    public static int SumNumbers(params int[] numbers) => numbers.Sum();
}

public static class MethodExample5
{
    public static void Main()
    {
        GetInput("Скільки у вас є яблук: ", out var age);
        var evaluation = EvaluateApplesAmount(in age);
        Console.WriteLine($"Ми оцінюємо ваш стратегічний запас як: {evaluation}.");
    }
    
    private static void GetInput(in string message, out int input)
    {
        do
            Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out input)); 
    }

    private static string EvaluateApplesAmount(in int number) => number <= 2 ? "мало" : "поїсти хватить";
}

public static class MethodExample6
{
    public static void Main()
    {
        var number = 0;
        Console.WriteLine($"Initial value: {number}.");
        Increment(ref number);
        Console.WriteLine($"Number has increased and it's value: {number}.");
    }

    private static void Increment(ref int number) => number++;
}

public static class MethodExample7
{
    public static void Main() => Console.WriteLine(MakeShortStory(name: "Андрій", age: 22, profession: "програміст"));

    private static string MakeShortStory(string name, string profession, int age) 
        => $"{name} проснувся одного ранку і зрозумів, що йому {age} років. Він порадів, що його професія - {profession}.";
}

public static class MethodExample8
{
    public static void Main() => Console.WriteLine(MakeGreeting("Чувак"));
    
    private static string MakeGreeting(string name, int age = 18) 
        => $"Привіт, {name}. Ми раді, що ти живеш в цьому світі уже {age} років!";
}

public static class MethodExample9
{
    public static void Main()
    {
        var result = Sum(1, 2, 5, 7);
        var result2 = Sum(1.3, 5.95, 7.33);
        var result3 = Sum(4.1f, 2f);
    }

    private static int Sum(params int[] nums) => nums.Sum();
    private static double Sum(params double[] nums) => nums.Sum();
    private static float Sum(params float[] nums) => nums.Sum();
}