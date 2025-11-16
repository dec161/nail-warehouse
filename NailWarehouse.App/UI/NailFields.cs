using NailWarehouse.App.Infrastructure;
using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Поля для создания объекта <see cref="Nail"/>.
/// </summary>
public partial class NailFields : UserControl
{
    /// <summary>
    /// Создаёт <see cref="NailFields"/>.
    /// </summary>
    public NailFields()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Привязывает свойства объекта <see cref="Nail"/> к полям и настраивает <see cref="ErrorProvider"/>.
    /// </summary>
    public void Bind(Nail nail)
    {
        NameTextBox.AddBinding(textBox => textBox.Text, nail, nail => nail.Name, ErrorProvider);
        NailSizeFields.AddBinding(nailSizeFields => nailSizeFields.NailSize, nail, nail => nail.Size, ErrorProvider);
        MaterialComboBox.AddEnumBinding(nail, nail => nail.Material, ErrorProvider);
        AmountNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nail, nail => nail.Amount, ErrorProvider);
        MinAmountNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nail, nail => nail.MinAmount, ErrorProvider);
        PriceNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nail, nail => nail.Price, ErrorProvider);

        SetFieldValues(nail);
    }

    private void SetFieldValues(Nail nail)
    {
        NailSizeFields.SetFieldValues(nail);

        nail.Amount = Math.Clamp(nail.Amount, NailConstants.MinAmount, NailConstants.MaxAmount);
        nail.MinAmount = Math.Clamp(nail.MinAmount, NailConstants.MinMinAmount, NailConstants.MaxMinAmount);
        nail.Price = Math.Clamp(nail.Price, NailConstants.MinPrice, NailConstants.MaxPrice);

        NameTextBox.MaxLength = NailConstants.MaxNameLength;
        AmountNumericUpDown.Minimum = NailConstants.MinAmount;
        AmountNumericUpDown.Maximum = NailConstants.MaxAmount;
        MinAmountNumericUpDown.Minimum = NailConstants.MinMinAmount;
        MinAmountNumericUpDown.Maximum = NailConstants.MaxMinAmount;
        PriceNumericUpDown.Minimum = NailConstants.MinPrice;
        PriceNumericUpDown.Maximum = NailConstants.MaxPrice;
    }
}
