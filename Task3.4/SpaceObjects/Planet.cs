using System.Text.Json.Serialization;
using Common.Extensions;
using Common.Tables.API;

namespace Task3_4.SpaceObjects;

[Serializable]
public class Planet : ITableItem
{
    /// <summary>
    /// Number specified in quadrillions(10^15).
    /// </summary>
    [NonSerialized] public const double MinimalLiversCount = Math.E;
    
    public string Name { get; }
    public PlanetSize Size { get; }
    public bool Habitable { get; set; }
    public PlanetType Type { get; }
    public double OrbitTurnoverDays { get; }
    public Star Star { get; }

    [field: NonSerialized]
    [JsonIgnore]
    public double LivingCreaturesCount
    {
        get
        {
            if (!Habitable)
                return 0;
            return ((int)Size)+1 * MinimalLiversCount;
        }
    }

    public Planet(string name, PlanetSize size, bool habitable, PlanetType type, double orbitTurnoverDays, Star star) =>
        (Name, Size, Habitable, Type, OrbitTurnoverDays, Star)
        = (name, size, habitable, type, orbitTurnoverDays, star);

    [NonSerialized]
    private static readonly string[] _infoHeaders  = {
        "Назва",
        "Розмір",
        "Придат. для Життя",
        "Тип планети",
        "Час оберту",
        "Зоря",
    };

    public string[] GetInfoHeaders() => _infoHeaders;

    public string[] GetFullInfo() => new[]
    {
        Name,
        Size.GetDisplayName(),
        Habitable ? "Так" : "Ні",
        Type.GetDisplayName(),
        OrbitTurnoverDays + " дн.",
        Star.ToString()
    };
}