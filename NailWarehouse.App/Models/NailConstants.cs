namespace NailWarehouse.App.Models;

/// <summary>
/// Константы.
/// </summary>
internal static class NailConstants
{
    /// <summary>
    /// Минимальная длина названия гвоздя.
    /// </summary>
    public const int MaxNameLength = 30;

    /// <summary>
    /// Минимальный диаметр гвоздя.
    /// </summary>
    public const float MinDiameter = 0.5f;
    
    /// <summary>
    /// Минимальный диаметр гвоздя.
    /// </summary>
    public const float MaxDiameter = 100f;

    /// <summary>
    /// Минимальная длина гвоздя.
    /// </summary>
    public const uint MinLength = 1u;

    /// <summary>
    /// Минимальная длина гвоздя.
    /// </summary>
    public const uint MaxLength = 1000u;

    /// <summary>
    /// Минимальное количество гвоздей.
    /// </summary>
    public const uint MinAmount = 0u;

    /// <summary>
    /// Максимальное количество гвоздей.
    /// </summary>
    public const uint MaxAmount = 100000u;

    /// <summary>
    /// Наименьший минимальный предел количества гвоздей.
    /// </summary>
    public const uint MinMinAmount = 0u;

    /// <summary>
    /// Наибольший минимальный предел количества гвоздей.
    /// </summary>
    public const uint MaxMinAmount = 10000u;

    /// <summary>
    /// Минимальная цена.
    /// </summary>
    public const decimal MinPrice = 1m;

    /// <summary>
    /// Максимальная цена.
    /// </summary>
    public const decimal MaxPrice = 10000m;
}
