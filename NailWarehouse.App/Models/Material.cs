namespace NailWarehouse.App.Models;

/// <summary>
/// Материал. Enum-подобный класс.
/// </summary>
public record class Material
{
    private readonly string value;

    private static readonly HashSet<Material> Materials = [];

    /// <summary>
    /// Не указан.
    /// </summary>
    public static readonly Material Null = Create("Не указан");

    /// <summary>
    /// Медь.
    /// </summary>
    public static readonly Material Copper = Create("Медь");

    /// <summary>
    /// Сталь.
    /// </summary>
    public static readonly Material Steel = Create("Сталь");

    /// <summary>
    /// Железо.
    /// </summary>
    public static readonly Material Iron = Create("Железо");

    /// <summary>
    /// Хром.
    /// </summary>
    public static readonly Material Chrome = Create("Хром");

    /// <summary>
    /// Все материалы.
    /// </summary>
    public static readonly IReadOnlyList<Material> All = [.. Materials];

    private static Material Create(string value)
    {
        var material = new Material(value);
        Materials.Add(material);
        return material;
    }

    private Material(string value) =>
        this.value = value;

    /// <inheritdoc/>
    public override string ToString() =>
        value;

    /// <inheritdoc cref="ToString"/>
    public static implicit operator string(Material material) =>
        material.ToString();
}
