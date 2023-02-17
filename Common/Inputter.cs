namespace Common;

public static class Inputter
{
    public static void Init() => Console.InputEncoding = System.Text.Encoding.Unicode;

    public static void GetInput(string message, out int input,
        int min = int.MinValue, int max = int.MaxValue)
    {
        do
            Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out input) || !IsInRange(input, min, max)); 
    }

    public static void GetInput(string message, out double input, 
        double min = double.MinValue, double max = double.MaxValue)
    {
        do
            Console.Write(message);
        while (!double.TryParse(Console.ReadLine(), out input) || !IsInRange(input, min, max)); 
    }

    public static void GetInput(string message, out uint input,
        uint min = uint.MinValue, uint max = uint.MaxValue)
    {
        do
            Console.Write(message);
        while (!uint.TryParse(Console.ReadLine(), out input) || !IsInRange(input, min, max)); 
    }
    
    public static void GetInput(string message, out decimal input,
        decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
    {
        do
            Console.Write(message);
        while (!decimal.TryParse(Console.ReadLine(), out input) || !IsInRange(input, min, max)); 
    }
    
    public static void GetInput(string message, out string input)
    {
        do
        {
            Console.Write(message);
            input = Console.ReadLine() ?? string.Empty;
        }
        while (string.IsNullOrEmpty(input)); 
    }

    public static void GetInput(string message, out bool input)
    {
        var menu = new Menu.Menu(message, new[] { "Так", "Ні" });
        menu.Launch();
        input = menu.Input == 0;
    }

    private static bool IsInRange(int num, int min, int max) => num >= min && num <= max;
    private static bool IsInRange(double num, double min, double max) => num >= min && num <= max;
    private static bool IsInRange(uint num, uint min, uint max) => num >= min && num <= max;
    private static bool IsInRange(decimal num, decimal min, decimal max) => num >= min && num <= max;
}