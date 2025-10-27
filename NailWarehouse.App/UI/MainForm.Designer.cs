namespace NailWarehouse.App.UI;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        MenuStrip = new MenuStrip();
        AddButton = new ToolStripMenuItem();
        EditButton = new ToolStripMenuItem();
        DeleteButton = new ToolStripMenuItem();
        StatusStrip = new StatusStrip();
        TotalRowsLabel = new ToolStripStatusLabel();
        SeparatorRowsPrice = new ToolStripStatusLabel();
        TotalPriceLabel = new ToolStripStatusLabel();
        SeparatorPriceTotalPrice = new ToolStripStatusLabel();
        TaxedTotalPriceLabel = new ToolStripStatusLabel();
        DataGridView = new DataGridView();
        NameColumn = new DataGridViewTextBoxColumn();
        SizeColumn = new DataGridViewTextBoxColumn();
        MaterialColumn = new DataGridViewTextBoxColumn();
        AmountColumn = new DataGridViewTextBoxColumn();
        MinAmountColumn = new DataGridViewTextBoxColumn();
        PriceColumn = new DataGridViewTextBoxColumn();
        TotalPriceColumn = new DataGridViewTextBoxColumn();
        BindingSource = new BindingSource(components);
        MenuStrip.SuspendLayout();
        StatusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BindingSource).BeginInit();
        SuspendLayout();
        // 
        // MenuStrip
        // 
        MenuStrip.Items.AddRange(new ToolStripItem[] { AddButton, EditButton, DeleteButton });
        MenuStrip.Location = new Point(0, 0);
        MenuStrip.Name = "MenuStrip";
        MenuStrip.Size = new Size(800, 24);
        MenuStrip.TabIndex = 0;
        // 
        // AddButton
        // 
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(71, 20);
        AddButton.Text = "Добавить";
        AddButton.Click += AddButton_Click;
        // 
        // EditButton
        // 
        EditButton.Enabled = false;
        EditButton.Name = "EditButton";
        EditButton.Size = new Size(73, 20);
        EditButton.Text = "Изменить";
        EditButton.Click += EditButton_Click;
        // 
        // DeleteButton
        // 
        DeleteButton.Enabled = false;
        DeleteButton.Name = "DeleteButton";
        DeleteButton.Size = new Size(63, 20);
        DeleteButton.Text = "Удалить";
        DeleteButton.Click += DeleteButton_Click;
        // 
        // StatusStrip
        // 
        StatusStrip.Items.AddRange(new ToolStripItem[] { TotalRowsLabel, SeparatorRowsPrice, TotalPriceLabel, SeparatorPriceTotalPrice, TaxedTotalPriceLabel });
        StatusStrip.Location = new Point(0, 428);
        StatusStrip.Name = "StatusStrip";
        StatusStrip.Size = new Size(800, 22);
        StatusStrip.TabIndex = 1;
        // 
        // TotalRowsLabel
        // 
        TotalRowsLabel.Name = "TotalRowsLabel";
        TotalRowsLabel.Size = new Size(88, 17);
        TotalRowsLabel.Text = "TotalRowsLabel";
        // 
        // SeparatorRowsPrice
        // 
        SeparatorRowsPrice.Name = "SeparatorRowsPrice";
        SeparatorRowsPrice.Size = new Size(10, 17);
        SeparatorRowsPrice.Text = "|";
        // 
        // TotalPriceLabel
        // 
        TotalPriceLabel.Name = "TotalPriceLabel";
        TotalPriceLabel.Size = new Size(86, 17);
        TotalPriceLabel.Text = "TotalPriceLabel";
        // 
        // SeparatorPriceTotalPrice
        // 
        SeparatorPriceTotalPrice.Name = "SeparatorPriceTotalPrice";
        SeparatorPriceTotalPrice.Size = new Size(10, 17);
        SeparatorPriceTotalPrice.Text = "|";
        // 
        // TaxedTotalPriceLabel
        // 
        TaxedTotalPriceLabel.Name = "TaxedTotalPriceLabel";
        TaxedTotalPriceLabel.Size = new Size(116, 17);
        TaxedTotalPriceLabel.Text = "TaxedTotalPriceLabel";
        // 
        // DataGridView
        // 
        DataGridView.AllowUserToAddRows = false;
        DataGridView.AllowUserToDeleteRows = false;
        DataGridView.AllowUserToResizeRows = false;
        DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DataGridView.Columns.AddRange(new DataGridViewColumn[] { NameColumn, SizeColumn, MaterialColumn, AmountColumn, MinAmountColumn, PriceColumn, TotalPriceColumn });
        DataGridView.Dock = DockStyle.Fill;
        DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        DataGridView.Location = new Point(0, 24);
        DataGridView.MultiSelect = false;
        DataGridView.Name = "DataGridView";
        DataGridView.ReadOnly = true;
        DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DataGridView.Size = new Size(800, 404);
        DataGridView.TabIndex = 2;
        DataGridView.CellContentDoubleClick += DataGridView_CellContentDoubleClick;
        DataGridView.CellFormatting += DataGridView_CellFormatting;
        DataGridView.SelectionChanged += DataGridView_SelectionChanged;
        // 
        // NameColumn
        // 
        NameColumn.FillWeight = 200F;
        NameColumn.HeaderText = "Название";
        NameColumn.Name = "NameColumn";
        NameColumn.ReadOnly = true;
        // 
        // SizeColumn
        // 
        SizeColumn.HeaderText = "Размер (мм)";
        SizeColumn.Name = "SizeColumn";
        SizeColumn.ReadOnly = true;
        // 
        // MaterialColumn
        // 
        MaterialColumn.FillWeight = 75F;
        MaterialColumn.HeaderText = "Материал";
        MaterialColumn.Name = "MaterialColumn";
        MaterialColumn.ReadOnly = true;
        // 
        // AmountColumn
        // 
        AmountColumn.FillWeight = 80F;
        AmountColumn.HeaderText = "Количество на складе";
        AmountColumn.Name = "AmountColumn";
        AmountColumn.ReadOnly = true;
        // 
        // MinAmountColumn
        // 
        MinAmountColumn.HeaderText = "Минимальный предел количества";
        MinAmountColumn.Name = "MinAmountColumn";
        MinAmountColumn.ReadOnly = true;
        // 
        // PriceColumn
        // 
        PriceColumn.FillWeight = 90F;
        PriceColumn.HeaderText = "Цена без НДС (руб.)";
        PriceColumn.Name = "PriceColumn";
        PriceColumn.ReadOnly = true;
        // 
        // TotalPriceColumn
        // 
        TotalPriceColumn.HeaderText = "Общая сумма товара (руб.)";
        TotalPriceColumn.Name = "TotalPriceColumn";
        TotalPriceColumn.ReadOnly = true;
        // 
        // BindingSource
        // 
        BindingSource.ListChanged += BindingSource_ListChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(DataGridView);
        Controls.Add(StatusStrip);
        Controls.Add(MenuStrip);
        MainMenuStrip = MenuStrip;
        Name = "MainForm";
        Text = "Склад гвоздей";
        Load += MainForm_Load;
        MenuStrip.ResumeLayout(false);
        MenuStrip.PerformLayout();
        StatusStrip.ResumeLayout(false);
        StatusStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)BindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip MenuStrip;
    private ToolStripMenuItem AddButton;
    private StatusStrip StatusStrip;
    private DataGridView DataGridView;
    private ToolStripMenuItem EditButton;
    private ToolStripMenuItem DeleteButton;
    private ToolStripStatusLabel TotalRowsLabel;
    private ToolStripStatusLabel TotalPriceLabel;
    private ToolStripStatusLabel TaxedTotalPriceLabel;
    private BindingSource BindingSource;
    private ToolStripStatusLabel SeparatorRowsPrice;
    private ToolStripStatusLabel SeparatorPriceTotalPrice;
    private DataGridViewTextBoxColumn NameColumn;
    private DataGridViewTextBoxColumn SizeColumn;
    private DataGridViewTextBoxColumn MaterialColumn;
    private DataGridViewTextBoxColumn AmountColumn;
    private DataGridViewTextBoxColumn MinAmountColumn;
    private DataGridViewTextBoxColumn PriceColumn;
    private DataGridViewTextBoxColumn TotalPriceColumn;
}