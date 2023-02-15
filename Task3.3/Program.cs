using Common;
using Common.DataSave;
using Common.DataSave.API;
using Common.Menu;
using Common.Tables;

namespace Task3_3;

public static class Program
{
    private static readonly IRepository<StudentGrades> _repository = 
        new PersistantRepository<StudentGrades>("grades.txt");

    private static readonly RepositoryBasicProcessor<StudentGrades>
        _repositoryProcessor = new(_repository, "Оцінки студентів");

    private static readonly Menu _menu = new("Електронний журнал", new Option []
    {
        new("Переглянути всі оцінки", _repositoryProcessor.ShowAll),
        new("Переглянути студентів, що не склали жодного іспиту", ShowFailedStudents),
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

    private static void ShowFailedStudents()
    {
        if (!_repository.Any())
        {
            Console.WriteLine("Записи відсутні.");
            return;
        }
        
        var filteredRecords = _repository
            .Where(student => student.Grades
                .All(grade => grade < 3));
        
        if (!filteredRecords.Any())
        {
            Console.WriteLine($"Студенти, що не склали жодного іспиту, відсутні.");
            return;
        }
        
        _repositoryProcessor.ShowTable("Студенти без успішних іспитів", filteredRecords);
    }

    private static void AddRecord()
    {
        Console.WriteLine("\tДодавання нового запису в базу");
        Inputter.GetInput("ПІБ:", out var name);
        Inputter.GetInput("Оцінка за математику(від 1 до 5):", out var math, 1, 5);
        Inputter.GetInput("Оцінка за прогармування(від 1 до 5):", out var programming, 1, 5);
        Inputter.GetInput("Оцінка за ТІМС(від 1 до 5):", out var probabilitiesAndStatistics, 1, 5);
        Inputter.GetInput("Оцінка за філософію(від 1 до 5):", out var philosophy, 1, 5);

        var record = new StudentGrades(name, math, programming, probabilitiesAndStatistics, philosophy);
        _repository.Add(record);
        Console.WriteLine("\nУспішно додано.\n");
    }

    private static void Exit()
    {
        Console.WriteLine("Гарного дня! ;)");
        Environment.Exit(0);
    }
}