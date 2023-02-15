using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Common.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var standardName = value.ToString();
        
        var name = value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()!
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
        
        return string.IsNullOrEmpty(name) ? standardName : name;
    }
}