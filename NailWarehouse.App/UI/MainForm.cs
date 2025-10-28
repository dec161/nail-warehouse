using System.ComponentModel;
using NailWarehouse.App.Infrastructure;
using NailWarehouse.App.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Основная форма.
/// </summary>
public partial class MainForm : Form
{
    private const decimal Tax = 0.2m;

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
        var totalPrice = nails.Sum(CalculateTotalPrice);
        var taxedTotalPrice = totalPrice * (1m + Tax);

        TotalRowsLabel.Text = $"Общее количество товарных позиций: {totalRows}";
        TotalPriceLabel.Text = $"Общая сумма товаров без НДС: {totalPrice:c}";
        TaxedTotalPriceLabel.Text = $"Общая сумма товаров с НДС {Tax:p0}: {taxedTotalPrice:c}";
    }

    private void UpdateCalculatedFields(int rowIndex)
    {
        if (BindingSource[rowIndex] is not NailType nailType)
        {
            return;
        }

        DataGridView
            .Rows[rowIndex]
            .Cells[TotalPriceColumn.Index]
            .Value = CalculateTotalPrice(nailType);
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

        DataGridView.DataSource = BindingSource;

        for (var rowIndex = 0; rowIndex < BindingSource.Count; rowIndex++)
        {
            UpdateCalculatedFields(rowIndex);
        }
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
        if (NailTypeForm.AskDeleteNailType() == DialogResult.OK)
        {
            BindingSource.RemoveCurrent();
        }
    }

    private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) =>
        EditSelection();

    private void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        var anyRowsSelected = DataGridView.SelectedRows.Count > 0;

        EditButton.Enabled = anyRowsSelected;
        DeleteButton.Enabled = anyRowsSelected;
    }

    private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value is Material material)
        {
            e.Value = material.GetDisplayName();
        }
    }

    private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType != ListChangedType.ItemMoved)
        {
            UpdateStats();
        }

        if (e.ListChangedType == ListChangedType.ItemChanged
            || e.ListChangedType == ListChangedType.ItemAdded)
        {
            UpdateCalculatedFields(e.NewIndex);
        }
    }

    private static decimal CalculateTotalPrice(NailType nailType) =>
        nailType.Amount * nailType.Price;
}
