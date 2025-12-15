using NailWarehouse.Entities.Models;
using System.ComponentModel;

namespace NailWarehouse.App.Services;

/// <summary>
/// Редактор для <see cref="Nail"/>,
/// позволяющий откатывать изменения.
/// Применяет поверхностное копирование.
/// </summary>
internal class NailEditor(Nail nail) : IEditableObject
{
    private bool isEditing = false;
    private Nail? backup = null;
    private readonly Nail nail = nail;

    public void BeginEdit()
    {
        if (isEditing)
        {
            return;
        }

        backup = new()
        {
            Id = nail.Id
        };

        ShallowClone(nail, backup);
        isEditing = true;
    }

    public void CancelEdit()
    {
        if (!isEditing || backup is null)
        {
            return;
        }

        ShallowClone(backup, nail);
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

    private static void ShallowClone(Nail source, Nail target)
    {
        target.Name = source.Name;
        target.Size = source.Size;
        target.Material = source.Material;
        target.Amount = source.Amount;
        target.MinAmount = source.MinAmount;
        target.Price = source.Price;
    }
}
