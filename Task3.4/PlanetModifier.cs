using Common;
using Common.DataSave.API;
using Common.Extensions;
using Common.Menu;
using Task3_4.SpaceObjects;

namespace Task3_4;

public class PlanetModifier
{
    public Planet CreatePlanet(IRepository<Planet> planets)
    {
        Console.WriteLine("\tСтворення планети");
        Inputter.GetInput("Введіть назву:", out string name);
        var size = GetPlanetSize();
        Inputter.GetInput("Планета придатна для життя: ", out bool habitable);
        var type = GetPlanetType();
        Inputter.GetInput("Днів для оберту навколо зорі:", out var orbitTurnover, 0, double.MaxValue);
        Console.WriteLine("Далі, для існування планети необхідно створити зірку.");
        var star = CreateStar(planets);
        
        return new(name, size, habitable, type, orbitTurnover, star);
    }
    
    public PlanetSize GetPlanetSize()
    {
        var possibleTypes = Enum.GetValues<PlanetSize>();
        var options = possibleTypes.Select(option => option.GetDisplayName());
        var menu = new Menu("Вибір розміру планети", options);
        menu.Launch();
        return (PlanetSize)menu.Input;
    }
        
    public PlanetType GetPlanetType()
    {
        var possibleTypes = Enum.GetValues<PlanetType>();
        var options = possibleTypes.Select(option => option.GetDisplayName());
        var menu = new Menu("Вибір типу планети", options);
        menu.Launch();
        return (PlanetType)menu.Input;
    }
    
    public Star CreateStar(IRepository<Planet> planets)
    {
        Console.WriteLine("\n\tСтворення зорі");
        string id;
        while (true)
        {        
            Inputter.GetInput("Введіть ідентифікатор(текст):", out id);
            if(planets.All(planet => planet.Star.Id != id))
                break;
            Console.WriteLine($"В одній з планет уже існує зоря з ідентифікатором {id}. Оберіть інший.");
        }
        Inputter.GetInput("Введіть назву:", out string name);
        var type = GetStarType();
        Inputter.GetInput("Введіть кількість планет, що має ця зоря(більше 0): ", out var planetCount, 1);
        
        var star = new Star(id, name, type, planetCount);
        return star;
    }
    
    public StarType GetStarType()
    {
        var possibleTypes = Enum.GetValues<StarType>();
        var options = possibleTypes.Select(option => option.GetDisplayName());
        var menu = new Menu("Вибір типу зорі", options);
        menu.Launch();
        return (StarType)menu.Input;
    }

    public bool AskDestroyingLifeConfirm(Planet planet)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Inputter.GetInput($"Ви впевненні, що хочете знищити все живе на планеті {planet.Name}?",
            out bool finalConfirmation);
        Console.ForegroundColor = currentColor;
        
        if (finalConfirmation) return true;
        
        Console.WriteLine("Відміна знищення життя. Дякуємо, що змилувались.");
        return false;

    }

    public int GetPlanetInputForAction(IRepository<Planet> planets, string actionName)
    {
        Inputter.GetInput($"Введіть номер(глобальний) планети, на якій треба {actionName} або 0, щоб відмінити цю дію: ",
            out var input, 0, planets.Count());
        return input;
    }

    public void ShowTerminationLifeWarning()
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Увага, вдостовіртесь, що на обраній планеті для знищення життя не має важливих для вас істот!");
        Console.WriteLine("Після вибору планети зараз - ви вб'єте все живе на ній!");
        Console.ForegroundColor = currentColor;
    }

    public void ShowKilledStatistics(double creaturesKilled)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ви убили {0:0.##} трільйона живих істот. Живіть тепер з цим.", creaturesKilled);
        Console.ForegroundColor = currentColor;
    }

    public void ShowCreationLifeStatistics(Planet planet)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ви дали життя {0:0.##} трільйонам істот. Планета наповнилась радістю.",
            planet.LivingCreaturesCount);
        Console.ForegroundColor = currentColor;
    }
}