using NailWarehouse.App.Services;
using NailWarehouse.Entities.Models;

namespace NailWarehouse.App.UI;

/// <summary>
/// Форма для создания и редактирования пользователем объектов <see cref="Nail"/>.
/// </summary>
public partial class NailForm : Form
{
    private NailForm(Nail nail)
    {
        InitializeComponent();
        NailFields.Bind(nail);
    }

    /// <summary>
    /// Показывает модальное окно для создания нового <see cref="Nail"/>.
    /// </summary>
    /// <returns>Объект <see cref="Nail"/>, если форма была заполнена; <c>null</c> иначе.</returns>
    public static Nail? CreateNail()
    {
        var nail = new Nail();
        using var form = new NailForm(nail);
        return form.ShowDialog() == DialogResult.OK
            ? nail
            : null;
    }

    /// <summary>
    /// Показывает модальное окна для изменения существующего <see cref="Nail"/>.
    /// </summary>
    /// <param name="nail">Объект <see cref="Nail"/> для изменения.</param>
    /// <returns><c>true</c>, если изменения были сохранены; <c>false</c>, если отменены.</returns>
    public static bool EditNail(Nail nail)
    {
        var editor = new NailEditor(nail);
        editor.BeginEdit();
        using var form = new NailForm(nail);

        var result = form.ShowDialog() == DialogResult.OK;

        if (result)
        {
            editor.EndEdit();
        }
        else
        {
            editor.CancelEdit();
        }

        return result;
    }

    /// <summary>
    /// Отображает <see cref="MessageBox"/> для подтверждения удаления пользователем.
    /// </summary>
    /// <returns><see cref="DialogResult.OK>"/> или <see cref="DialogResult.Cancel"/>.</returns>
    public static DialogResult AskDeleteNail() =>
        MessageBox.Show("Вы уверены?",
            "Удаление",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning);

    private void NailForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult != DialogResult.Cancel)
        {
            e.Cancel = !NailFields.ValidateChildren();
        }
    }
}
