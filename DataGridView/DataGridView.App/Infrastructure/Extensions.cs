using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace DataGridView.App.Infrastructure
{
    /// <summary>
    /// Статический класс методов расширения
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Добавить Binding
        /// </summary>
        public static void AddBinding<TControl, TSource>(
            this TControl control, // тип элемента управления
            Expression<Func<TControl, object>> destinationProperty, // свойство контрола, которое будет связано
            TSource source, // тип модели данных
            Expression<Func<TSource, object>> sourceProperty, // свойство модели, которое будет связано
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var destPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            var existing = control.DataBindings[destPropName];
            if (existing != null)
            {
                control.DataBindings.Remove(existing);
            }

            var binding = new Binding(destPropName, source, sourcePropName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourcePropName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    control.Validating += (sender, e) =>
                    {
                        var context = new ValidationContext(source) { MemberName = sourcePropName };
                        var results = new List<ValidationResult>();

                        errorProvider.SetError(control, string.Empty);

                        var propertyValue = sourcePropertyInfo?.GetValue(source);
                        var isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        if (!isValid)
                        {
                            var erorrs = results.Where(r =>
                                r.MemberNames.Contains(sourcePropName) ||
                                !r.MemberNames.Any()
                            );
                            foreach (var error in erorrs)
                            {
                                errorProvider.SetError(control, error.ErrorMessage);
                            }
                        }
                    };
                }
            }
        }

        /// <summary>
        /// Вернуть отображаемое имя Enum
        /// </summary>
        public static string GetDisplayName(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            if (member != null)
            {
                var attr = member.GetCustomAttribute<DisplayAttribute>();
                if (attr != null)
                {
                    return attr.Name;
                }
            }
            return value.ToString();
        }

        private static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            var body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Выражение должно быть доступом к свойству", nameof(expression));
        }

    }
}
