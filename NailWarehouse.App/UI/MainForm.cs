using System.ComponentModel;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityExtensions;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.Infrastructure;

namespace NailWarehouse.App.UI;

/// <summary>
/// Основная форма.
/// </summary>
public partial class MainForm : Form
{
    private CancellationTokenSource CancellationTokenSource { get; } = new();

    private INailManager NailManager { get; }

    /// <summary>
    /// Создаёт <see cref="MainForm"/>.
    /// </summary>
    public MainForm(INailManager nailManager)
    {
        NailManager = nailManager;
        InitializeComponent();
    }

    private async Task UpdateDataSource()
    {
        BindingSource.DataSource = await NailManager.GetAll(CancellationTokenSource.Token);
        BindingSource.ResetBindings(false);
    }

    private async Task UpdateStatistics()
    {
        var nailStatistics = await NailManager.GetStatistics(CancellationTokenSource.Token);

        TotalRowsLabel.Text = $"Общее количество товарных позиций: {nailStatistics.TotalRows}";
        TotalPriceLabel.Text = $"Общая сумма товаров без НДС: {nailStatistics.TotalPrice:c}";
        TaxedTotalPriceLabel.Text =
            $"Общая сумма товаров с НДС {nailStatistics.Tax:p0}: {nailStatistics.TaxedTotalPrice:c}";
    }

    private void UpdateCalculatedFields(int rowIndex)
    {
        if (BindingSource[rowIndex] is not Nail nail)
        {
            return;
        }

        DataGridView
            .Rows[rowIndex]
            .Cells[TotalPriceColumn.Index]
            .Value = nail.CalculateTotalPrice();
    }

    private async Task EditSelection()
    {
        if (BindingSource.Current is not Nail nail)
        {
            return;
        }

        if (NailForm.EditNail(nail))
        {
            await NailManager.Update(nail, CancellationTokenSource.Token);
        }

        BindingSource.ResetCurrentItem();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        BindingSource.DataSource = await NailManager.GetAll(CancellationTokenSource.Token);

        DataGridView.AutoGenerateColumns = false;

        NameColumn.DataPropertyName = nameof(Nail.Name);
        SizeColumn.DataPropertyName = nameof(Nail.Size);
        MaterialColumn.DataPropertyName = nameof(Nail.Material);
        AmountColumn.DataPropertyName = nameof(Nail.Amount);
        MinAmountColumn.DataPropertyName = nameof(Nail.MinAmount);
        PriceColumn.DataPropertyName = nameof(Nail.Price);

        DataGridView.DataSource = BindingSource;
    }

    private async void AddButton_Click(object sender, EventArgs e)
    {
        if (NailForm.CreateNail() is Nail nail)
        {
            await NailManager.Add(nail, CancellationTokenSource.Token);
            _ = UpdateDataSource();
        }
    }

    private void EditButton_Click(object sender, EventArgs e) =>
        _ = EditSelection();

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (NailForm.AskDeleteNail() == DialogResult.OK
            && BindingSource.Current is Nail current)
        {
            await NailManager.Remove(current, CancellationTokenSource.Token);
            _ = UpdateDataSource();
        }
    }

    private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) =>
        _ = EditSelection();

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
        else if (e.ColumnIndex == 0)
        {
            UpdateCalculatedFields(e.RowIndex);
        }
    }

    private void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType != ListChangedType.ItemMoved)
        {
            _ = UpdateStatistics();
        }

        if (e.ListChangedType == ListChangedType.ItemChanged
            || e.ListChangedType == ListChangedType.ItemAdded)
        {
            UpdateCalculatedFields(e.NewIndex);
        }
    }

    private void UpdateButton_Click(object sender, EventArgs e) =>
        _ = UpdateDataSource();

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        CancellationTokenSource.Cancel();
    }
}
