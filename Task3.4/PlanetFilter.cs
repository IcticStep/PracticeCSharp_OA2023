using Common.DataSave.API;
using Task3_4.SpaceObjects;

namespace Task3_4;

public class PlanetFilter
{
    private readonly IRepository<Planet> _planets;

    public PlanetFilter(IRepository<Planet> planets) => _planets = planets;

    public IEnumerable<Planet> GetPlanetsWithLive() => _planets.Where(planet => planet.Habitable);
    public IEnumerable<Planet> GetPlanetsWithoutLive() => _planets.Where(planet => !planet.Habitable);
    public IEnumerable<Planet> GetPlanetsByType(PlanetType type) => _planets.Where(planet => planet.Type == type);
    public IEnumerable<Planet> GetPlanetsBySize(PlanetSize size) => _planets.Where(planet => planet.Size == size);
}