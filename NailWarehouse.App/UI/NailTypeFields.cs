using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Поля для создания объекта <see cref="NailType"/>.
/// </summary>
public partial class NailTypeFields : UserControl
{
    private readonly IEnumerable<ValidationAttribute> materialValidationAttributes =
    [
        new DeniedValuesAttribute(Material.Null)
        {
            ErrorMessage = "Поле \"{0}\" содержит недопустимое значение."
        }
    ];

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
        AddBinding(NameTextBox, nameof(TextBox.Text), nailType, nameof(NailType.Name));
        AddBinding(NailSizeFields, nameof(NailSizeFields.NailSize), nailType, nameof(NailType.Size));
        AddBinding(AmountNumericUpDown, nameof(NumericUpDown.Value), nailType, nameof(NailType.Amount));
        AddBinding(MinAmountNumericUpDown, nameof(NumericUpDown.Value), nailType, nameof(NailType.MinAmount));
        AddBinding(PriceNumericUpDown, nameof(NumericUpDown.Value), nailType, nameof(NailType.Price));

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

    private void AddBinding(Control control, string propertyName, NailType dataSource, string dataMember)
    {
        var binding = new Binding(propertyName, dataSource, dataMember)
        {
            DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
        };
        control.DataBindings.Add(binding);

        if (dataSource.GetType().GetProperty(dataMember) is not PropertyInfo info)
        {
            return;
        }

        var validationAttributes = Attribute.GetCustomAttributes(info, typeof(ValidationAttribute));

        if (validationAttributes.Length <= 0)
        {
            return;
        }

        control.Validating += (sender, e) =>
        {
            ErrorProvider.SetError(control, string.Empty);

            var context = new ValidationContext(dataSource)
            {
                MemberName = dataMember
            };

            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(info.GetValue(dataSource), context, results))
            {
                e.Cancel = true;
                if (results.FirstOrDefault() is ValidationResult result)
                {
                    ErrorProvider.SetError(control, result.ErrorMessage);
                }
            }
        };
    }

    private void AddMaterialBinding(NailType dataSource)
    {
        MaterialComboBox.DataSource = Material.All;

        var propertyName = nameof(ComboBox.SelectedItem);
        var dataMember = nameof(NailType.Material);

        var binding = new Binding(propertyName, dataSource, dataMember)
        {
            DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
        };
        MaterialComboBox.DataBindings.Add(binding);

        MaterialComboBox.Validating += (sender, e) =>
        {
            ErrorProvider.SetError(MaterialComboBox, string.Empty);

            var context = new ValidationContext(dataSource)
            {
                MemberName = dataMember
            };

            var results = new List<ValidationResult>();

            if (!Validator.TryValidateValue(MaterialComboBox.SelectedItem, context, results, materialValidationAttributes))
            {
                e.Cancel = true;
                if (results.FirstOrDefault() is ValidationResult result)
                {
                    ErrorProvider.SetError(MaterialComboBox, result.ErrorMessage);
                }
            }
        };
    }
}
