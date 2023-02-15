using Common;
using Common.Extensions;
using Common.Menu;
using Common.Tables;

namespace Task3_2;

public static class Program
{
    private static readonly FileRepository _repository = new("tapeRecorders.txt");
    private static List<TapeRecorder> _records = new();

    private static readonly Menu _menu = new("Облік магнітофонів", new Option []
    {
        new("Переглянути всі", ShowAll),
        new("Переглянути за категорією", ShowByType),
        new("Додати запис", AddRecord),
        new("Вилучити запис", RemoveRecord),
        new("Вийти", Exit)
    });

    public static void Main()
    {
        Init();
        LoadRecords();
        
        while(true)
            _menu.Launch();
    }

    private static void Init()
    {
        Inputter.Init();
        Outputter.Init();
    }

    private static void LoadRecords()
    {
        var loadedData = _repository.Load<TapeRecorder>();

        if (loadedData == null)
        {
            Console.WriteLine("Файл записів відсутній. Програма створить новий, коли ви щось додасте.");
            return;
        }

        _records = loadedData.ToList();
    }

    private static void ShowAll()
    {
        if (!_records.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        ShowTable("Магнітофони", _records);
    }

    private static void ShowByType()
    {
        if (!_records.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        var selectedType = GetInputType();
        var selectedTypeName = selectedType.GetDisplayName();
        var filteredRecords = _records.Where(recorder => recorder.Type == selectedType);
        
        if (!filteredRecords.Any())
        {
            Console.WriteLine($"Записи типу \"{selectedTypeName}\" відсутні.");
            return;
        }
        
        ShowTable($"Магнітофони типу \"{selectedTypeName}\"", filteredRecords);
    }

    private static void AddRecord()
    {
        var maxYear = Convert.ToUInt32(DateTime.Today.Year);
        
        Console.WriteLine("\tДодавання нового запису в базу");
        Inputter.GetInput("Ім'я:", out var name);
        Inputter.GetInput("Виробник:", out var manufacturer);
        Inputter.GetInput("Місто:", out var city);
        Inputter.GetInput("Рік:", out var year, 0, maxYear);
        var type = GetInputType();
        Inputter.GetInput("Ціна:", out var price, 0M);
        Inputter.GetInput("Кількість: ", out var count, 0);

        var record = new TapeRecorder(name, manufacturer, city, year, type, price, count);
        _records.Add(record);
        SaveData();
    }

    private static void RemoveRecord()
    {
        if (!_records.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        Console.WriteLine("Видалення об'єкту");
        Inputter.GetInput("Введіть номер запису, який треба видалити або 0 щоб відмінити видалення: ",
            out var input, 0, _records.Count);

        if (input == 0)
        {
            Console.WriteLine("Відміна видалення.");
            return;
        }

        _records.RemoveAt(input - 1);
        SaveData();
        Console.WriteLine("Видалення пройшло успішно.");
    }

    private static void Exit()
    {
        Console.WriteLine("Гарного дня! ;)");
        Environment.Exit(0);
    }

    private static void ShowTable(string name, IEnumerable<TapeRecorder> tapeRecorders) 
        => new TableOutput(name, tapeRecorders).Show();

    private static void SaveData() => _repository.Save(_records);

    private static Type GetInputType()
    {
        var possibleTypes = Enum.GetValues<Type>();
        var options = possibleTypes.Select(option => option.GetDisplayName());
        var menu = new Menu("Вибір типу радіо", options);
        menu.Launch();
        return (Type)menu.Input;
    }
}