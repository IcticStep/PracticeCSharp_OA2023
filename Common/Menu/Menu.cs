namespace Common.Menu;

public class Menu
{
    private const string InputHint = "Оберіть варіант, ввівши його номер: ";
    private readonly string _name;
    private readonly List<Option> _options;

    public int Input { get; private set; }

    public Menu(string name, IEnumerable<Option> options) 
        => (_name, _options) = (name, options.ToList());

    public Menu(string name, IEnumerable<string> options) : this(name,
        options.Select(option => new Option(option, null))) { }

    public void Launch()
    {
        ShowMenu();
        GetInput();
        Console.WriteLine();
        InvokeInputtedOption();
    }

    private void ShowMenu()
    {
        ShowTitle();
        ShowMenuOptions();
    }

    private void ShowMenuOptions()
    {
        for (var i = 0; i < _options.Count; i++)
            ShowMenuOption(i);
        Console.WriteLine();
    }

    private void ShowTitle() => Console.WriteLine($"\n\t\t{_name}");
    private void ShowMenuOption(int i) => Console.WriteLine($"\t{i+1}) - {_options[i].Name}");

    private void GetInput()
    {
        Inputter.GetInput($"\t{InputHint}", out var input, 1, _options.Count + 1);
        Input = --input;
    }

    private void InvokeInputtedOption() => _options[Input].Method?.Invoke();
}