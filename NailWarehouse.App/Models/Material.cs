using System.ComponentModel.DataAnnotations;

namespace NailWarehouse.App.Models;

/// <summary>
/// Материал.
/// </summary>
public enum Material
{
    /// <summary>
    /// Не указан.
    /// </summary>
    [Display(Name = "Не указан")]
    Null,

    /// <summary>
    /// Медь.
    /// </summary>
    [Display(Name = "Медь")]
    Copper,

    /// <summary>
    /// Сталь.
    /// </summary>
    [Display(Name = "Сталь")]
    Steel,

    /// <summary>
    /// Железо.
    /// </summary>
    [Display(Name = "Железо")]
    Iron,

    /// <summary>
    /// Хром.
    /// </summary>
    [Display(Name = "Хром")]
    Chrome
}
