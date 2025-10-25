namespace NailWarehouse.App.UI;

partial class NailTypeFields
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        TableLayoutPanel = new TableLayoutPanel();
        NailSizeLabel = new Label();
        NameTextBox = new TextBox();
        NameLabel = new Label();
        MaterialComboBox = new ComboBox();
        AmountNumericUpDown = new NumericUpDown();
        MinAmountNumericUpDown = new NumericUpDown();
        PriceNumericUpDown = new NumericUpDown();
        MaterialLabel = new Label();
        AmountLabel = new Label();
        MinAmountLabel = new Label();
        PriceLabel = new Label();
        NailSizeFields = new NailSizeFields();
        ErrorProvider = new ErrorProvider(components);
        TableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)AmountNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)MinAmountNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
        SuspendLayout();
        // 
        // TableLayoutPanel
        // 
        TableLayoutPanel.ColumnCount = 3;
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        TableLayoutPanel.Controls.Add(NailSizeLabel, 0, 1);
        TableLayoutPanel.Controls.Add(NameTextBox, 1, 0);
        TableLayoutPanel.Controls.Add(NameLabel, 0, 0);
        TableLayoutPanel.Controls.Add(MaterialComboBox, 1, 2);
        TableLayoutPanel.Controls.Add(AmountNumericUpDown, 1, 3);
        TableLayoutPanel.Controls.Add(MinAmountNumericUpDown, 1, 4);
        TableLayoutPanel.Controls.Add(PriceNumericUpDown, 1, 5);
        TableLayoutPanel.Controls.Add(MaterialLabel, 0, 2);
        TableLayoutPanel.Controls.Add(AmountLabel, 0, 3);
        TableLayoutPanel.Controls.Add(MinAmountLabel, 0, 4);
        TableLayoutPanel.Controls.Add(PriceLabel, 0, 5);
        TableLayoutPanel.Controls.Add(NailSizeFields, 1, 1);
        TableLayoutPanel.Dock = DockStyle.Fill;
        TableLayoutPanel.Location = new Point(0, 0);
        TableLayoutPanel.Name = "TableLayoutPanel";
        TableLayoutPanel.RowCount = 6;
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666622F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666622F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666622F));
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
        TableLayoutPanel.Size = new Size(403, 222);
        TableLayoutPanel.TabIndex = 5;
        // 
        // NailSizeLabel
        // 
        NailSizeLabel.AutoSize = true;
        NailSizeLabel.Dock = DockStyle.Fill;
        NailSizeLabel.Location = new Point(3, 37);
        NailSizeLabel.Name = "NailSizeLabel";
        NailSizeLabel.Size = new Size(201, 37);
        NailSizeLabel.TabIndex = 17;
        NailSizeLabel.Text = "Размер (мм):";
        NailSizeLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // NameTextBox
        // 
        NameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        NameTextBox.Location = new Point(210, 7);
        NameTextBox.Name = "NameTextBox";
        NameTextBox.Size = new Size(170, 23);
        NameTextBox.TabIndex = 2;
        // 
        // NameLabel
        // 
        NameLabel.AutoSize = true;
        NameLabel.Dock = DockStyle.Fill;
        NameLabel.Location = new Point(3, 0);
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new Size(201, 37);
        NameLabel.TabIndex = 3;
        NameLabel.Text = "Название:";
        NameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MaterialComboBox
        // 
        MaterialComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        MaterialComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        MaterialComboBox.FormattingEnabled = true;
        MaterialComboBox.Location = new Point(210, 80);
        MaterialComboBox.Name = "MaterialComboBox";
        MaterialComboBox.Size = new Size(170, 23);
        MaterialComboBox.TabIndex = 15;
        // 
        // AmountNumericUpDown
        // 
        AmountNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        AmountNumericUpDown.Location = new Point(210, 116);
        AmountNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        AmountNumericUpDown.Name = "AmountNumericUpDown";
        AmountNumericUpDown.Size = new Size(170, 23);
        AmountNumericUpDown.TabIndex = 12;
        // 
        // MinAmountNumericUpDown
        // 
        MinAmountNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        MinAmountNumericUpDown.Location = new Point(210, 152);
        MinAmountNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        MinAmountNumericUpDown.Name = "MinAmountNumericUpDown";
        MinAmountNumericUpDown.Size = new Size(170, 23);
        MinAmountNumericUpDown.TabIndex = 13;
        // 
        // PriceNumericUpDown
        // 
        PriceNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        PriceNumericUpDown.Location = new Point(210, 190);
        PriceNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        PriceNumericUpDown.Name = "PriceNumericUpDown";
        PriceNumericUpDown.Size = new Size(170, 23);
        PriceNumericUpDown.TabIndex = 14;
        // 
        // MaterialLabel
        // 
        MaterialLabel.AutoSize = true;
        MaterialLabel.Dock = DockStyle.Fill;
        MaterialLabel.Location = new Point(3, 74);
        MaterialLabel.Name = "MaterialLabel";
        MaterialLabel.Size = new Size(201, 36);
        MaterialLabel.TabIndex = 6;
        MaterialLabel.Text = "Материал:";
        MaterialLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // AmountLabel
        // 
        AmountLabel.AutoSize = true;
        AmountLabel.Dock = DockStyle.Fill;
        AmountLabel.Location = new Point(3, 110);
        AmountLabel.Name = "AmountLabel";
        AmountLabel.Size = new Size(201, 36);
        AmountLabel.TabIndex = 7;
        AmountLabel.Text = "Количество на складе:";
        AmountLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MinAmountLabel
        // 
        MinAmountLabel.AutoSize = true;
        MinAmountLabel.Dock = DockStyle.Fill;
        MinAmountLabel.Location = new Point(3, 146);
        MinAmountLabel.Name = "MinAmountLabel";
        MinAmountLabel.Size = new Size(201, 36);
        MinAmountLabel.TabIndex = 8;
        MinAmountLabel.Text = "Минимальный предел количества:";
        MinAmountLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // PriceLabel
        // 
        PriceLabel.AutoSize = true;
        PriceLabel.Dock = DockStyle.Fill;
        PriceLabel.Location = new Point(3, 182);
        PriceLabel.Name = "PriceLabel";
        PriceLabel.Size = new Size(201, 40);
        PriceLabel.TabIndex = 9;
        PriceLabel.Text = "Цена без НДС (руб.):";
        PriceLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // NailSizeFields
        // 
        NailSizeFields.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        NailSizeFields.Location = new Point(210, 40);
        NailSizeFields.Name = "NailSizeFields";
        NailSizeFields.Size = new Size(170, 31);
        NailSizeFields.TabIndex = 16;
        // 
        // ErrorProvider
        // 
        ErrorProvider.ContainerControl = this;
        // 
        // NailTypeFields
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(TableLayoutPanel);
        Name = "NailTypeFields";
        Size = new Size(403, 222);
        TableLayoutPanel.ResumeLayout(false);
        TableLayoutPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)AmountNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)MinAmountNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel TableLayoutPanel;
    private TextBox NameTextBox;
    private Label NameLabel;
    private Label MinAmountLabel;
    private Label AmountLabel;
    private Label MaterialLabel;
    private NumericUpDown AmountNumericUpDown;
    private NumericUpDown MinAmountNumericUpDown;
    private ComboBox MaterialComboBox;
    private Label PriceLabel;
    private NumericUpDown PriceNumericUpDown;
    private Label NailSizeLabel;
    private NailSizeFields NailSizeFields;
    private ErrorProvider ErrorProvider;
}
