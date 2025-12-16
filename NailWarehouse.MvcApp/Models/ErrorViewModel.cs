namespace NailWarehouse.MvcApp.Models;

/// <summary>
/// Модель представления для страницы ошибки.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Идентификатор запроса.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Флаг для отображения идентификатора запроса.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
