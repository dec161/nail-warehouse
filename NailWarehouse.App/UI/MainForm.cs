using System.ComponentModel;
using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Основная форма.
/// </summary>
public partial class MainForm : Form
{
    private const decimal Tax = 0.2m;
    private const string TotalRowsTemplate = "Общее количество товарных позиций: {0}";
    private const string TotalPriceTemplate = "Общая сумма товаров без НДС: {0:c}";
    private const string DeleteMessageBoxTitle = "Удаление";
    private const string DeleteMessageBoxText = "Вы уверены?";

    private static readonly string TaxedTotalPriceTemplate = $"Общая сумма товаров с НДС {Tax:p0}: {{0:c}}";

    private readonly BindingList<NailType> nails =
    [
        new()
        {
            Name = "Строительные гвозди",
            Size = new(3.5f, 90u),
            Material = Material.Chrome,
            Amount = 2u,
            MinAmount = 1u,
            Price = 3m
        },
        new()
        {
            Name = "Гвозди с потайной головкой",
            Size = new(4f, 100u),
            Material = Material.Steel,
            Amount = 4u,
            MinAmount = 2u,
            Price = 6m
        },
        new()
        {
            Name = "Ершеные гвозди",
            Size = new(2f, 150u),
            Material = Material.Iron,
            Amount = 5u,
            MinAmount = 2u,
            Price = 4.5m
        }
    ];

    /// <summary>
    /// Создаёт <see cref="MainForm"/>.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
    }

    private void UpdateStats()
    {
        var totalRows = nails.Count;
        var totalPrice = nails.Sum(nailType => nailType.TotalPrice);
        var taxedTotalPrice = totalPrice * (1m + Tax);

        TotalRowsLabel.Text = string.Format(TotalRowsTemplate, totalRows);
        TotalPriceLabel.Text = string.Format(TotalPriceTemplate, totalPrice);
        TaxedTotalPriceLabel.Text = string.Format(TaxedTotalPriceTemplate, taxedTotalPrice);
    }

    private void EditSelection()
    {
        var nailType = (NailType)BindingSource.Current;
        NailTypeForm.EditNailType(nailType);
        BindingSource.ResetCurrentItem();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        BindingSource.DataSource = nails;

        DataGridView.AutoGenerateColumns = false;

        NameColumn.DataPropertyName = nameof(NailType.Name);
        SizeColumn.DataPropertyName = nameof(NailType.Size);
        MaterialColumn.DataPropertyName = nameof(NailType.Material);
        AmountColumn.DataPropertyName = nameof(NailType.Amount);
        MinAmountColumn.DataPropertyName = nameof(NailType.MinAmount);
        PriceColumn.DataPropertyName = nameof(NailType.Price);
        TotalPriceColumn.DataPropertyName = nameof(NailType.TotalPrice);

        DataGridView.DataSource = BindingSource;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        if (NailTypeForm.CreateNailType() is NailType nailType)
        {
            nails.Add(nailType);
        }
    }

    private void EditButton_Click(object sender, EventArgs e) =>
        EditSelection();

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        var response = MessageBox.Show(DeleteMessageBoxText,
            DeleteMessageBoxTitle,
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning);

        if (response == DialogResult.OK)
        {
            BindingSource.RemoveCurrent();
        }
    }

    private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) =>
        EditSelection();

    private void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        var anyRowsSelected = DataGridView.SelectedRows.Count > 0;

        EditButton.Enabled = anyRowsSelected;
        DeleteButton.Enabled = anyRowsSelected;
    }

    private void BindingSource_ListChanged(object sender, ListChangedEventArgs e) =>
        UpdateStats();
}
