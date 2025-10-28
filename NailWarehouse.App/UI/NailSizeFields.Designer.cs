namespace NailWarehouse.App.UI;

partial class NailSizeFields
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
        TableLayoutPanel = new TableLayoutPanel();
        DiameterNumericUpDown = new NumericUpDown();
        LengthNumericUpDown = new NumericUpDown();
        XLabel = new Label();
        TableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DiameterNumericUpDown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)LengthNumericUpDown).BeginInit();
        SuspendLayout();
        // 
        // TableLayoutPanel
        // 
        TableLayoutPanel.ColumnCount = 3;
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
        TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
        TableLayoutPanel.Controls.Add(DiameterNumericUpDown, 0, 0);
        TableLayoutPanel.Controls.Add(LengthNumericUpDown, 2, 0);
        TableLayoutPanel.Controls.Add(XLabel, 1, 0);
        TableLayoutPanel.Dock = DockStyle.Fill;
        TableLayoutPanel.Location = new Point(0, 0);
        TableLayoutPanel.Name = "TableLayoutPanel";
        TableLayoutPanel.RowCount = 1;
        TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        TableLayoutPanel.Size = new Size(155, 29);
        TableLayoutPanel.TabIndex = 0;
        // 
        // DiameterNumericUpDown
        // 
        DiameterNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        DiameterNumericUpDown.DecimalPlaces = 1;
        DiameterNumericUpDown.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
        DiameterNumericUpDown.Location = new Point(3, 3);
        DiameterNumericUpDown.Name = "DiameterNumericUpDown";
        DiameterNumericUpDown.Size = new Size(61, 23);
        DiameterNumericUpDown.TabIndex = 11;
        // 
        // LengthNumericUpDown
        // 
        LengthNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        LengthNumericUpDown.Location = new Point(89, 3);
        LengthNumericUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        LengthNumericUpDown.Name = "LengthNumericUpDown";
        LengthNumericUpDown.Size = new Size(63, 23);
        LengthNumericUpDown.TabIndex = 13;
        // 
        // XLabel
        // 
        XLabel.AutoSize = true;
        XLabel.Dock = DockStyle.Fill;
        XLabel.Location = new Point(70, 0);
        XLabel.Name = "XLabel";
        XLabel.Size = new Size(13, 29);
        XLabel.TabIndex = 14;
        XLabel.Text = "x";
        XLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // NailSizeFields
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(TableLayoutPanel);
        Name = "NailSizeFields";
        Size = new Size(155, 29);
        TableLayoutPanel.ResumeLayout(false);
        TableLayoutPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)DiameterNumericUpDown).EndInit();
        ((System.ComponentModel.ISupportInitialize)LengthNumericUpDown).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel TableLayoutPanel;
    private NumericUpDown DiameterNumericUpDown;
    private NumericUpDown LengthNumericUpDown;
    private Label XLabel;
}
