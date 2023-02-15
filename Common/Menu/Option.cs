namespace Common.Menu;

public class Option
{
    public string Name { get; }
    public Action? Method { get; }

    public Option(string name, Action? method)
    {
        Name = name;
        Method = method;
    }
}