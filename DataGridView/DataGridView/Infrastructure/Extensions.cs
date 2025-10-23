using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace DataGridView.Infrastructure
{
    /// <summary>
    /// Класс расширений для работы с привязкой данных и валидацией в Windows Forms
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Создает двухстороннюю привязку данных между свойством элемента управления и свойством модели данных
        /// </summary>
        public static void AddBinding<TControl, TSource, TProperty>(
            this TControl control,
            Expression<Func<TControl, TProperty>> controlProperty,
            TSource source,
            Expression<Func<TSource, TProperty>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var controlPropName = GetPropertyName(controlProperty);
            var sourcePropName = GetPropertyName(sourceProperty);

            // Удаляем существующую привязку, если есть
            var existing = control.DataBindings[controlPropName];
            if (existing != null)
            {
                control.DataBindings.Remove(existing);
            }

            // Создаём новую привязку
            var binding = new Binding(controlPropName, source, sourcePropName, true)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            // Подключаем валидацию, если указан ErrorProvider
            if (errorProvider != null)
            {
                AddValidation(control, source, sourcePropName, errorProvider);
            }
        }

        /// <summary>
        /// Добавление валидации к контролу
        /// </summary>
        private static void AddValidation<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
            {
                return;
            }

            control.Validating += (sender, e) =>
            {
                ValidateControl(control, source, sourcePropertyName, errorProvider);
            };
        }

        /// <summary>
        /// Валидация конкретного контрола
        /// </summary>
        private static void ValidateControl<TControl, TSource>(
            TControl control,
            TSource source,
            string sourcePropertyName,
            ErrorProvider errorProvider)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyInfo = source.GetType().GetProperty(sourcePropertyName);
            if (sourcePropertyInfo == null)
            {
                return;
            }

            var context = new ValidationContext(source) { MemberName = sourcePropertyName };
            var results = new List<ValidationResult>();

            var propertyValue = sourcePropertyInfo.GetValue(source);
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            errorProvider.SetError(control, isValid ? string.Empty : results.FirstOrDefault()?.ErrorMessage ?? string.Empty);
        }

        /// <summary>
        /// Извлекает имя свойства из лямбда-выражения
        /// </summary>
        private static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (expression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
            {
                return operand.Member.Name;
            }

            throw new ArgumentException("Expression must be a property access.", nameof(expression));
        }
    }
}
