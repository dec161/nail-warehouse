using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Поля для создания объекта <see cref="Models.NailSize"/>.
/// </summary>
public partial class NailSizeFields : UserControl
{
    /// <summary>
    /// Получает объект <see cref="Models.NailSize"/> из введёных значений или устанавливает значения полей.
    /// </summary>
    public NailSize NailSize
    {
        get => new((float)DiameterNumericUpDown.Value, (uint)LengthNumericUpDown.Value);
        set
        {
            DiameterNumericUpDown.Value = (decimal)value.Diameter;
            LengthNumericUpDown.Value = value.Length;
        }
    }

    /// <summary>
    /// Создаёт <see cref="NailSizeFields"/>.
    /// </summary>
    public NailSizeFields()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Устанавливает подходящие значения полей.
    /// </summary>
    public void SetFieldValues(NailType nailType)
    {
        nailType.Size = new(Math.Clamp(nailType.Size.Diameter, NailConstants.MinDiameter, NailConstants.MaxDiameter),
            Math.Clamp(nailType.Size.Length, NailConstants.MinLength, NailConstants.MaxLength));
        
        DiameterNumericUpDown.Minimum = (decimal)NailConstants.MinDiameter;
        DiameterNumericUpDown.Maximum = (decimal)NailConstants.MaxDiameter;
        LengthNumericUpDown.Minimum = NailConstants.MinLength;
        LengthNumericUpDown.Maximum = NailConstants.MaxLength;
    }
}
