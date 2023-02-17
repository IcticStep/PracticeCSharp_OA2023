using System.ComponentModel.DataAnnotations;

namespace Task3_4.SpaceObjects;

public enum PlanetType
{
    [Display(Name = "Гігантська планета")]
    GiantPlanet,
    [Display(Name = "Крижаний гігант")]
    IceGiant,
    [Display(Name = "Мезопланета")]
    Mesoplanet,
    [Display(Name = "Міні-Нептун")]
    MiniNeptune,
    [Display(Name = "Планетар")]
    Planetar,
    [Display(Name = "Супер-Земля")]
    SuperEarth,
    [Display(Name = "Супер-Юпітер")]
    SuperJupiter,
    [Display(Name = "Мініземля")]
    SubEarth
}