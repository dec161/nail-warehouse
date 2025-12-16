using NailWarehouse.Constants;
using NailWarehouse.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace NailWarehouse.MvcApp.Models;

/// <summary>
/// Модель презентации для страницы формы <see cref="Nail"/>.
/// </summary>
public class NailFormViewModel
{
    private const string RangeErrorMessage =
        "Значение поля '{0}' не должно выходить за пределы диапазона [{1}; {2}].";
    private const string RequiredErrorMessage =
        "Поле '{0}' не должно быть пустым.";
    private const string MaterialErrorMessage =
        "В поле '{0}' должно быть указано значение.";

    /// <summary>
    /// Название страницы.
    /// </summary>
    public string PageTitle { get; set; } = string.Empty;

    /// <inheritdoc cref="Nail.Id"/>
    public Guid? Id { get; set; }

    /// <inheritdoc cref="Nail.Name"/>
    [Display(Name = "Название")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(NailConstants.MaxNameLength,
        ErrorMessage = "Поле '{0}' не должно содержать более {1} символов.")]
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc cref="NailSize.Diameter"/>
    [Display(Name = "Диаметр")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(NailConstants.MinDiameter, NailConstants.MaxDiameter,
        ErrorMessage = RangeErrorMessage)]
    public float Diameter { get; set; }

    /// <inheritdoc cref="NailSize.Length"/>
    [Display(Name = "Длина")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(NailConstants.MinLength, NailConstants.MaxLength,
        ErrorMessage = RangeErrorMessage)]
    public uint Length { get; set; }

    /// <inheritdoc cref="Nail.Material"/>
    [Display(Name = "Материал")]
    [Required(ErrorMessage = MaterialErrorMessage)]
    [DeniedValues(Material.Null,
        ErrorMessage = MaterialErrorMessage)]
    public Material Material { get; set; } = Material.Null;

    /// <inheritdoc cref="Nail.Amount"/>
    [Display(Name = "Количество на складе")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(NailConstants.MinAmount, NailConstants.MaxAmount,
        ErrorMessage = RangeErrorMessage)]
    public uint Amount { get; set; }

    /// <inheritdoc cref="Nail.MinAmount"/>
    [Display(Name = "Минимальный предел количества")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(NailConstants.MinMinAmount, NailConstants.MaxMinAmount,
        ErrorMessage = RangeErrorMessage)]
    public uint MinAmount { get; set; }

    /// <inheritdoc cref="Nail.Price"/>
    [Display(Name = "Цена")]
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range((double)NailConstants.MinPrice, (double)NailConstants.MaxPrice,
        ErrorMessage = RangeErrorMessage)]
    public decimal Price { get; set; }
}
