namespace NailWarehouse.App.Models;

/// <summary>
/// Размер гвоздя.
/// </summary>
/// <param name="Diameter">Диаметр.</param>
/// <param name="Length">Длина.</param>
public readonly record struct NailSize(float Diameter, uint Length)
{
    /// <summary>
    /// Преобразует размер в строку.
    /// </summary>
    /// <returns>Строка в формате диаметр x длина.</returns>
    public override string ToString() =>
        $"{Diameter: 0.0} x {Length}";
}
