using NailWarehouse.App.Infrastructure;
using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Поля для создания объекта <see cref="NailType"/>.
/// </summary>
public partial class NailTypeFields : UserControl
{
    /// <summary>
    /// Создаёт <see cref="NailTypeFields"/>.
    /// </summary>
    public NailTypeFields()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Привязывает свойства объекта <see cref="NailType"/> к полям и настраивает <see cref="ErrorProvider"/>.
    /// </summary>
    public void Bind(NailType nailType)
    {
        NameTextBox.AddBinding(textBox => textBox.Text, nailType, nailType => nailType.Name, ErrorProvider);
        NailSizeFields.AddBinding(nailSizeFields => nailSizeFields.NailSize, nailType, nailType => nailType.Size, ErrorProvider);
        AmountNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nailType, nailType => nailType.Amount, ErrorProvider);
        MinAmountNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nailType, nailType => nailType.MinAmount, ErrorProvider);
        PriceNumericUpDown.AddBinding(numericUpDown => numericUpDown.Value, nailType, nailType => nailType.Price, ErrorProvider);

        AddMaterialBinding(nailType);

        SetFieldValues(nailType);
    }

    private void SetFieldValues(NailType nailType)
    {
        NailSizeFields.SetFieldValues(nailType);

        nailType.Amount = Math.Clamp(nailType.Amount, NailConstants.MinAmount, NailConstants.MaxAmount);
        nailType.MinAmount = Math.Clamp(nailType.MinAmount, NailConstants.MinMinAmount, NailConstants.MaxMinAmount);
        nailType.Price = Math.Clamp(nailType.Price, NailConstants.MinPrice, NailConstants.MaxPrice);

        NameTextBox.MaxLength = NailConstants.MaxNameLength;
        AmountNumericUpDown.Minimum = NailConstants.MinAmount;
        AmountNumericUpDown.Maximum = NailConstants.MaxAmount;
        MinAmountNumericUpDown.Minimum = NailConstants.MinMinAmount;
        MinAmountNumericUpDown.Maximum = NailConstants.MaxMinAmount;
        PriceNumericUpDown.Minimum = NailConstants.MinPrice;
        PriceNumericUpDown.Maximum = NailConstants.MaxPrice;
    }

    private void AddMaterialBinding(NailType dataSource)
    {
        var materials = Enum.GetValues(typeof(Material))
            .Cast<Material>()
            .Select(material => new { Value = material, Name = material.GetDisplayName() })
            .ToArray();
        MaterialComboBox.DataSource = materials;

        var material = materials[0];
        MaterialComboBox.DisplayMember = nameof(material.Name);
        MaterialComboBox.ValueMember = nameof(material.Value);

        MaterialComboBox.AddBinding(comboBox => comboBox.SelectedValue!, dataSource, nailType => nailType.Material, ErrorProvider);
    }
}
