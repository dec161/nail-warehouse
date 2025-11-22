namespace NailWarehouse.App.UI;

partial class NailTypeForm
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
        SaveButton = new Button();
        CancelEditButton = new Button();
        NailTypeFields = new NailTypeFields();
        SuspendLayout();
        // 
        // SaveButton
        // 
        SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        SaveButton.DialogResult = DialogResult.OK;
        SaveButton.Location = new Point(336, 236);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(75, 23);
        SaveButton.TabIndex = 0;
        SaveButton.Text = "Сохранить";
        SaveButton.UseVisualStyleBackColor = true;
        // 
        // CancelEditButton
        // 
        CancelEditButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        CancelEditButton.CausesValidation = false;
        CancelEditButton.DialogResult = DialogResult.Cancel;
        CancelEditButton.Location = new Point(417, 236);
        CancelEditButton.Name = "CancelEditButton";
        CancelEditButton.Size = new Size(75, 23);
        CancelEditButton.TabIndex = 1;
        CancelEditButton.Text = "Отмена";
        CancelEditButton.UseVisualStyleBackColor = true;
        // 
        // NailTypeFields
        // 
        NailTypeFields.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        NailTypeFields.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        NailTypeFields.Location = new Point(12, 12);
        NailTypeFields.Name = "NailTypeFields";
        NailTypeFields.Size = new Size(480, 218);
        NailTypeFields.TabIndex = 4;
        // 
        // NailTypeForm
        // 
        AcceptButton = SaveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = CancelEditButton;
        ClientSize = new Size(504, 271);
        ControlBox = false;
        Controls.Add(CancelEditButton);
        Controls.Add(SaveButton);
        Controls.Add(NailTypeFields);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "NailTypeForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Редактирование";
        FormClosing += NailTypeForm_FormClosing;
        ResumeLayout(false);
    }

    #endregion

    private Button SaveButton;
    private Button CancelEditButton;
    private NailTypeFields NailTypeFields;
}