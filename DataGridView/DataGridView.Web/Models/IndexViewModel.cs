
using DataGridView.Entities;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Коллекция аббитуриента для отображения на странице
        /// </summary>
        public IEnumerable<ApplicantModel> Applicants { get; set; } = Enumerable.Empty<ApplicantModel>();

        /// <summary>
        /// Статискита с числом всех студентов
        /// </summary>
        public int CountStatistics { get; set; } = new();

        /// <summary>
        /// Статистика с количеством студентов по минимвльному баллу
        /// </summary>
        public int CountByMinStatistics { get; set; } = new();
    }
}

