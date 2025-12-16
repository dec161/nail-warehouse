using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NailWarehouse.Infrastructure;

/// <summary>
/// Расширения для <see cref="Enum"/>.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Преобразует <paramref name="value"/> в строку.
    /// </summary>
    /// <returns>
    /// Значение атрибута <see cref="DisplayAttribute"/> для <paramref name="value"/>,
    /// если он есть; иначе, <c><paramref name="value"/>.ToString()</c>.
    /// </returns>
    public static string GetDisplayName(this Enum value)
    {
        var valueString = value.ToString();

        var attribute = value.GetType().GetMember(valueString).FirstOrDefault()
            ?.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

        return attribute?.Name ?? valueString;
    }
}
