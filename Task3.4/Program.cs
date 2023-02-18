using Common;
using Common.DataSave;
using Common.DataSave.API;
using Common.Menu;
using Task3_4.SpaceObjects;

namespace Task3_4;

public static class Program
{
    private static readonly IRepository<Planet> _planetsRepository = new PersistantRepository<Planet>("planets.txt");
    private static readonly RepositoryBasicProcessor<Planet> _repositoryProcessor = new(_planetsRepository, "Планети");
    private static readonly PlanetModifier _planetModifier = new();

    private static readonly Menu _menu = new("Симулятор галактики", new Option []
    {
        new("Переглянути всі планети", _repositoryProcessor.ShowAll),
        new("Фільтрувати планети за", FilterPlanetsBy),
        new("Створити планету", AddPlanet),
        new("Вилучити планету", _repositoryProcessor.RemoveRecord),
        new("Вбити життя", TerminateLife),
        new("Створити життя", CreateLife),
        new("Вийти", Exit)
    });

    public static void Main()
    {
        Init();

        while(true)
            _menu.Launch();
    }

    private static void Init()
    {
        Inputter.Init();
        Outputter.Init();
        
        _repositoryProcessor.CheckLoadedResources();
    }

    private static void AddPlanet()
    {
        var planet = _planetModifier.CreatePlanet(_planetsRepository);
        _planetsRepository.Add(planet);
        Console.WriteLine("\nУспішно додано.\n");
    }

    private static void TerminateLife()
    {
        Console.WriteLine("\tЗнищення життя на планеті.");
        _planetModifier.ShowTerminationLifeWarning();

        var input = _planetModifier.GetPlanetInputForAction(_planetsRepository, "знищити життя");
        if (input == 0)
        {
            Console.WriteLine("Відміна знищення життя. Дякуємо, що змилувались.");
            return;
        }

        var planet = _planetsRepository[input - 1];
        if (!planet.Habitable)
        {
            Console.WriteLine("Обрана планета і так непридатна для життя. Нікого вбито не було.");
            return;
        }
        
        if (!_planetModifier.AskDestroyingLifeConfirm(planet)) return;

        var creaturesKilled = planet.LivingCreaturesCount;
        planet.Habitable = false;
        _planetsRepository.ForceSave();
        
        _planetModifier.ShowKilledStatistics(creaturesKilled);
    }

    private static void CreateLife()
    {
        Console.WriteLine("\tСтворення життя на планеті.");
        var input = _planetModifier.GetPlanetInputForAction(_planetsRepository, "створити життя");
        if (input == 0)
        {
            Console.WriteLine("Дія відмінена.");
            return;
        }

        var planet = _planetsRepository[input - 1];

        if (planet.Habitable)
        {
            Console.WriteLine("Обрана планета і так придатна для життя. Нічого більш створено не було.");
            return;
        }
        
        planet.Habitable = true;
        _planetsRepository.ForceSave();

        _planetModifier.ShowCreationLifeStatistics(planet);
    }

    private static void FilterPlanetsBy()
    {
        var planetFilter = new PlanetFilter(_planetsRepository);
        new Menu("Фільтрувати планети за", new Option []
        {
            new("Присутністю життя", () => _repositoryProcessor
                .ShowTable("Планети з життям",planetFilter
                    .GetPlanetsWithLive())),
            
            new("Відсутністю життя", () => _repositoryProcessor
                .ShowTable("Планети без життя",planetFilter
                    .GetPlanetsWithoutLive())),
            
            new("Типом", () => _repositoryProcessor
                .ShowTable("Планети за обраним типом",planetFilter
                    .GetPlanetsByType(_planetModifier.GetPlanetType()))),
            
            new("Розміром", () => _repositoryProcessor
                .ShowTable("Планети за обраним розміром",planetFilter
                    .GetPlanetsBySize(_planetModifier.GetPlanetSize())))
        }).Launch();
    }

    private static void Exit()
    {
        Console.WriteLine("Гарного дня! ;)");
        Environment.Exit(0);
    }
}