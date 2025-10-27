using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace NailWarehouse.App.Infrastructure;

internal static class ControlExtensions
{
    /// <summary>
    /// Создаёт <see cref="Binding"/> и добавляет его в
    /// <see cref="Control.DataBindings"/> для <paramref name="control"/>.
    /// Если у полученного свойства для <paramref name="dataSource"/> есть <see cref="ValidationAttribute"/>s,
    /// то настраивает <paramref name="errorProvider"/> на отображение ошибок валидации.
    /// </summary>
    public static void AddBinding<TControl, TSource>(this TControl control,
        Expression<Func<TControl, object>> propertySelector,
        TSource dataSource,
        Expression<Func<TSource, object>> dataMemberSelector,
        ErrorProvider errorProvider)
        where TControl : Control
        where TSource : class
    {
        var controlPropertyInfo = GetPropertyInfo(propertySelector);
        var dataMemberInfo = GetPropertyInfo(dataMemberSelector);

        control.AddBinding(controlPropertyInfo.Name, dataSource, dataMemberInfo.Name);

        if (Attribute.GetCustomAttributes(dataMemberInfo, typeof(ValidationAttribute)).Length > 0)
        {
            control.AddError(dataSource, dataMemberInfo, errorProvider);
        }
    }

    private static void AddBinding(this Control control,
        string propertyName,
        object dataSource,
        string dataMember)
    {
        var binding = new Binding(propertyName, dataSource, dataMember)
        {
            DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
        };

        control.DataBindings.Add(binding);
    }

    private static void AddError(this Control control,
        object dataSource,
        PropertyInfo propertyInfo,
        ErrorProvider errorProvider)
    {
        control.Validating += (_, e) =>
        {
            errorProvider.SetError(control, string.Empty);

            var context = new ValidationContext(dataSource)
            {
                MemberName = propertyInfo.Name
            };

            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(propertyInfo.GetValue(dataSource), context, results))
            {
                e.Cancel = true;
                if (results.FirstOrDefault() is ValidationResult result)
                {
                    errorProvider.SetError(control, result.ErrorMessage);
                }
            }
        };
    }

    private static PropertyInfo GetPropertyInfo<TSource, TProperty>(
        Expression<Func<TSource, TProperty>> expression)
    {
        var body = (expression.Body as UnaryExpression)?.Operand
            ?? expression.Body;

        return (body as MemberExpression)?.Member as PropertyInfo
            ?? throw new ArgumentException("Expression must be a property access.", nameof(expression));
    }
}
