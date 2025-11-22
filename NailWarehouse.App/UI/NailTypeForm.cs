using NailWarehouse.App.Models;
using NailWarehouse.App.Services;

namespace NailWarehouse.App.UI;

/// <summary>
/// Форма для создания и редактирования пользователем объектов <see cref="NailType"/>.
/// </summary>
public partial class NailTypeForm : Form
{
    private NailTypeForm(NailType nailType)
    {
        InitializeComponent();
        NailTypeFields.Bind(nailType);
    }

    /// <summary>
    /// Показывает модальное окно для создания нового <see cref="NailType"/>.
    /// </summary>
    /// <returns>Объект <see cref="NailType"/>, если форма была заполнена; <c>null</c> иначе.</returns>
    public static NailType? CreateNailType()
    {
        var nailType = new NailType();
        using var form = new NailTypeForm(nailType);
        return form.ShowDialog() == DialogResult.OK
            ? nailType
            : null;
    }

    /// <summary>
    /// Показывает модальное окна для изменения существующего <see cref="NailType"/>.
    /// </summary>
    /// <param name="nailType">Объект <see cref="NailType"/> для изменения.</param>
    public static void EditNailType(NailType nailType)
    {
        var editor = new NailTypeEditor(nailType);
        editor.BeginEdit();
        using var form = new NailTypeForm(nailType);
        if (form.ShowDialog() == DialogResult.OK)
        {
            editor.EndEdit();
        }
        else
        {
            editor.CancelEdit();
        }
    }

    /// <summary>
    /// Отображает <see cref="MessageBox"/> для подтверждения удаления пользователем.
    /// </summary>
    /// <returns><see cref="DialogResult.OK>"/> или <see cref="DialogResult.Cancel"/>.</returns>
    public static DialogResult AskDeleteNailType() =>
        MessageBox.Show("Вы уверены?",
            "Удаление",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning);

    private void NailTypeForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult != DialogResult.Cancel)
        {
            e.Cancel = !NailTypeFields.ValidateChildren();
        }
    }
}
