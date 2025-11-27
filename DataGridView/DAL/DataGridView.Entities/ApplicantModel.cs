using System.ComponentModel.DataAnnotations;
using DataGridView.Entities.Attributes;
using DataGridView.Entities.Enums;
using DataGridView.Entities.Contracts;


namespace DataGridView.Entities
{
    /// <summary>
    /// Модель абитуриента
    /// </summary>
    public class ApplicantModel
    {
        /// <summary>
        /// Идентификатор абитуриента
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ФИО абитуриента
        /// </summary>
        [Required(ErrorMessage = "ФИО обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} должно быть от {2} до {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        [Required(ErrorMessage = "Пол обязателен")]
        public SexType Sex { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DateRange(EntityConstants.MinYear, EntityConstants.MaxYear)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Required(ErrorMessage = "Форма обучения обязательна")]
        public EducationType EducationForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Балл по информатике должен быть от 0 до 100")]
        public decimal MathScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому языку
        /// </summary>
        [Range(0, 100, ErrorMessage = "Балл по информатике должен быть от 0 до 100")]
        public decimal RussianScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Range(0, 100, ErrorMessage = "Балл по информатике должен быть от 0 до 100")]
        public decimal InformaticsScore { get; set; }

    }
}
