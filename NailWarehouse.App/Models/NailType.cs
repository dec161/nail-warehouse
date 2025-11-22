using System.ComponentModel.DataAnnotations;

namespace NailWarehouse.App.Models;

/// <summary>
/// Тип гвоздя.
/// </summary>
public class NailType
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Название.
    /// </summary>
    [Display(Name = "Название")]
    [Required(ErrorMessage = "Поле \"{0}\" не должно быть пустым.")]
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc cref="NailSize"/>
    public NailSize Size { get; set; }

    /// <inheritdoc cref="Models.Material"/>
    [Display(Name = "Материал")]
    [DeniedValues(Material.Null, ErrorMessage = "Поле \"{0}\" содержит недопустимое значение.")]
    public Material Material { get; set; } = Material.Null;

    /// <summary>
    /// Количество экземпляров на складе.
    /// </summary>
    public uint Amount { get; set; }

    /// <summary>
    /// Минимальный предел количества.
    /// </summary>
    public uint MinAmount { get; set; }

    /// <summary>
    /// Цена в рублях без НДС.
    /// </summary>
    public decimal Price { get; set; }
}
