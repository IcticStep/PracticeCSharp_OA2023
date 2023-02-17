using System.Text.Json.Serialization;
using Common.Extensions;
using Common.Tables.API;

namespace Task3_4.SpaceObjects;

[Serializable]
public class Star : ITableItem
{
    public string Id { get; }
    public string Name { get; }
    public StarType Type { get; }
    public int PlanetCount { get; }
    
    [NonSerialized]
    private static readonly string[] _infoHeaders  = {
        "ID",
        "Назва",
        "Тип",
        "К-сть. планет"
    };

    public Star(string id, string name, StarType type, int planetCount) => 
        (Id, Name, Type, PlanetCount) = (id, name, type, planetCount);

    public string[] GetInfoHeaders() => _infoHeaders;
    
    public string[] GetFullInfo() => new[]
    {
        Id,
        Name,
        Type.GetDisplayName(),
        PlanetCount.ToString()
    };

    public override string ToString() => $"{Id}[{Name}]|Тип {Type.GetDisplayName()}| {PlanetCount} планет";
}