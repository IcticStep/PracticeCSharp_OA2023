namespace Common;

public static class Inputter
{
    public static void GetInput(in string message, out double input)
    {
        do
            Console.Write(message);
        while (!double.TryParse(Console.ReadLine(), out input)); 
    }
}