using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Entities.Attributes
{
    /// <summary>
    /// Атрибут валидации для проверки возраста
    /// </summary>
    internal sealed class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime minDate;
        private readonly DateTime maxDate;

        /// <summary>
        /// ctor
        /// </summary>
        public DateRangeAttribute(int minAge, int maxAge)
        {
            if (minAge > maxAge)
            {
                throw new ArgumentException("Минимальный возраст больше максимального");
            }
            minDate = DateTime.Now.AddYears(-maxAge - 1).Date;
            maxDate = DateTime.Now.AddYears(-minAge).Date;
        }

        /// <summary>
        /// Проверка даты
        /// </summary>
        public override bool IsValid(object? value)
        {
            if (value is DateTime date && minDate <= date && date < maxDate)
            {
                return true;
            }
            ErrorMessage = $@"Дата должна быть в диапозоне от {minDate.ToShortDateString()} до {maxDate.ToShortDateString()}";
            return false;
        }
    }
}
