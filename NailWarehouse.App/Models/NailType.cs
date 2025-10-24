using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NailWarehouse.App.Models;

/// <summary>
/// Тип гвоздя.
/// </summary>
public class NailType : IEditableObject
{
    private bool isEditing = false;
    private NailType? backup = null;

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

    /// <summary>
    /// Общая сумма товара.
    /// </summary>
    public decimal TotalPrice => Amount * Price;

    public void BeginEdit()
    {
        if (isEditing)
        {
            return;
        }

        backup = (NailType)MemberwiseClone();
        isEditing = true;
    }

    public void CancelEdit()
    {
        if (!isEditing || backup is null)
        {
            return;
        }

        Name = backup.Name;
        Size = backup.Size;
        Material = backup.Material;
        Amount = backup.Amount;
        MinAmount = backup.MinAmount;
        Price = backup.Price;
        isEditing = false;
    }

    public void EndEdit()
    {
        if (!isEditing)
        {
            return;
        }

        backup = null;
        isEditing = false;
    }
}
