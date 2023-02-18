using Common;
using Common.DataSave;
using Common.DataSave.API;
using Common.Extensions;
using Common.Menu;

namespace Task3_2;

public static class Program
{
    private static readonly IRepository<TapeRecorder> _repository = 
        new PersistantRepository<TapeRecorder>("tapeRecorders.txt");

    private static readonly RepositoryBasicProcessor<TapeRecorder>
        _repositoryProcessor = new(_repository, "Магнітофони");

    private static readonly Menu _menu = new("Облік магнітофонів", new Option []
    {
        new("Переглянути всі", _repositoryProcessor.ShowAll),
        new("Переглянути за категорією", ShowByType),
        new("Додати запис", AddRecord),
        new("Вилучити запис", _repositoryProcessor.RemoveRecord),
        new("Вийти", Exit)
    });

    public static void Main()
    {
        Init();
        _repositoryProcessor.CheckLoadedResources();
        
        while(true)
            _menu.Launch();
    }

    private static void Init()
    {
        Inputter.Init();
        Outputter.Init();
    }

    private static void ShowByType()
    {
        if (!_repository.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        var selectedType = GetInputType();
        var selectedTypeName = selectedType.GetDisplayName();
        var filteredRecords = _repository.Where(recorder => recorder.Type == selectedType);
        
        if (!filteredRecords.Any())
        {
            Console.WriteLine($"Записи типу \"{selectedTypeName}\" відсутні.");
            return;
        }
        
        _repositoryProcessor.ShowTable($"Магнітофони типу \"{selectedTypeName}\"", filteredRecords);
    }

    private static void AddRecord()
    {
        var maxYear = Convert.ToUInt32(DateTime.Today.Year);
        
        Console.WriteLine("\tДодавання нового запису в базу");
        Inputter.GetInput("Назва:", out string name);
        Inputter.GetInput("Виробник:", out string manufacturer);
        Inputter.GetInput("Місто:", out string city);
        Inputter.GetInput("Рік:", out var year, 0, maxYear);
        var type = GetInputType();
        Inputter.GetInput("Ціна:", out var price, 0M);
        Inputter.GetInput("Кількість: ", out var count, 0);

        var record = new TapeRecorder(name, manufacturer, city, year, type, price, count);
        _repository.Add(record);
        Console.WriteLine("\nУспішно додано.\n");
    }

    private static void Exit()
    {
        Console.WriteLine("Гарного дня! ;)");
        Environment.Exit(0);
    }

    private static Type GetInputType()
    {
        var possibleTypes = Enum.GetValues<Type>();
        var options = possibleTypes.Select(option => option.GetDisplayName());
        var menu = new Menu("Вибір типу радіо", options);
        menu.Launch();
        return (Type)menu.Input;
    }
}