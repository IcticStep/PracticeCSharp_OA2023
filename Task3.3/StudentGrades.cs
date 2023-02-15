using System.Text.Json.Serialization;
using Common.Tables.API;

namespace Task3_3;

[Serializable]
public class StudentGrades : ITableItem
{
    public string FullName { get; }
    public int Math { get; }
    public int Programming { get; }
    public int ProbabilitiesAndStatistics { get; }
    public int Philosophy { get; }

    [JsonIgnore]
    public IEnumerable<int> Grades => new[] { Math, Programming, ProbabilitiesAndStatistics, Philosophy };

    [NonSerialized]
    private static readonly string[] _infoHeaders  = {
        "ПІБ",
        "Математика",
        "Програмування",
        "ТІМС",
        "Філософія",
    };

    public StudentGrades(string fullName, int math, int programming, int probabilitiesAndStatistics, int philosophy) =>
        (FullName, Math, Programming, ProbabilitiesAndStatistics, Philosophy)
        = (fullName, math, programming, probabilitiesAndStatistics, philosophy);

    public string[] GetInfoHeaders() => _infoHeaders;

    public string[] GetFullInfo() => new[]
        {
            FullName,
            Math.ToString(),
            Programming.ToString(),
            ProbabilitiesAndStatistics.ToString(),
            Philosophy.ToString()
        };
}