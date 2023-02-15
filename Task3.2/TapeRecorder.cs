using System.Globalization;
using Common.Extensions;
using Common.Tables.API;

namespace Task3_2;

[Serializable]
public class TapeRecorder : ITableItem
{
    private decimal _price;
    private int _count;
    
    [NonSerialized]
    private static readonly string[] _infoHeaders  = {
        "Назва",
        "Вибробник",
        "Місто",
        "Рік",
        "Вид",
        "Ціна",
        "Кількість"
    };

    public string Name { get; }
    public string Manufacturer { get; }
    public string City { get; }
    public uint Year { get; }
    public Type Type { get; }


    public decimal Price
    {
        get => _price;
        set => _price = value >= 0 ? value : _price;
    }

    public int Count
    {
        get => _count;
        set => _count = value >= 0 ? value : _count;
    }

    public TapeRecorder(string name, string manufacturer, string city, uint year, Type type, decimal price, int count) 
        => (Name, Manufacturer, City, Year, Type, Price, Count) = (name, manufacturer, city, year, type, price, count);

    public string[] GetInfoHeaders() => _infoHeaders;

    public string[] GetFullInfo() => new[]
    {
        Name,
        Manufacturer,
        City,
        Year.ToString(),
        Type.GetDisplayName(),
        _price.ToString(CultureInfo.InvariantCulture) + "$",
        _count.ToString()
    };
}