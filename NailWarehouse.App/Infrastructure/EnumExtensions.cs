using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NailWarehouse.App.Infrastructure;

internal static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var valueString = value.ToString();

        var attribute = value.GetType().GetMember(valueString).FirstOrDefault()
            ?.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
        
        return attribute?.Name ?? valueString;
    }
}
