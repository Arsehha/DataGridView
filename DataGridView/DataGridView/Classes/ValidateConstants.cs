using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Classes
{
    internal class ValidateConstants
    {
        // Константы для ApplicantModel

        /// <summary>
        /// Минимальная длина наименования товара
        /// </summary>
        public const int ApplicantNameMinLength = 2;

        /// <summary>
        /// Максимальная длина наименования товара
        /// </summary>
        public const int ApplicantNameMaxLength = 100;

        /// <summary>
        /// Максимальное количество баллов ЕГЭ
        /// </summary>
        public const int ApplicantMinScore = 0;

        /// <summary>
        /// Минимальное количество баллов ЕГЭ
        /// </summary>
        public const int ApplicantMaxScore = 0;
    }
}
