using NailWarehouse.App.Models;
using System.ComponentModel;

namespace NailWarehouse.App.Services;

/// <summary>
/// Редактор для <see cref="NailType"/>,
/// позволяющий откатывать изменения.
/// Применяет поверхностное копирование.
/// </summary>
internal class NailTypeEditor(NailType nailType) : IEditableObject
{
    private bool isEditing = false;
    private NailType? backup = null;
    private readonly NailType nailType = nailType;

    public void BeginEdit()
    {
        if (isEditing)
        {
            return;
        }

        backup = new()
        {
            Id = nailType.Id
        };

        ShallowClone(nailType, backup);
        
        isEditing = true;
    }

    public void CancelEdit()
    {
        if (!isEditing || backup is null)
        {
            return;
        }

        ShallowClone(backup, nailType);
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

    private static void ShallowClone(NailType source, NailType target)
    {
        target.Name = source.Name;
        target.Size = source.Size;
        target.Material = source.Material;
        target.Amount = source.Amount;
        target.MinAmount = source.MinAmount;
        target.Price = source.Price;
    }
}
