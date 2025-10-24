using System.ComponentModel.DataAnnotations;
using DataGridView.Classes;

namespace DataGridView.Models
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
        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "ФИО обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} должно быть от {2} до {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Пол обязателен")]
        public SexType Sex { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Дата рождения обязательна")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Display(Name = "Форма обучения")]
        [Required(ErrorMessage = "Форма обучения обязательна")]
        public EducationType EducationForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по математике")]
        [Range(0, 100, ErrorMessage = "Балл по математике должен быть от 0 до 100")]
        public int MathScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому языку
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по русскому языку")]
        [Range(0, 100, ErrorMessage = "Балл по русскому языку должен быть от 0 до 100")]
        public int RussianScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по информатике")]
        [Range(0, 100, ErrorMessage = "Балл по информатике должен быть от 0 до 100")]
        public int InformaticsScore { get; set; }

        /// <summary>
        /// Общая сумма баллов
        /// </summary>
        [Display(Name = "Общая сумма баллов")]
        public int TotalScore => MathScore + RussianScore + InformaticsScore;

        /// <summary>
        /// Создает копию объекта ApplicantModel
        /// </summary>
        public ApplicantModel Clone()
        {
            return new ApplicantModel
            {
                Id = Id,
                FullName = FullName,
                Sex = Sex,
                DateOfBirth = DateOfBirth,
                EducationForm = EducationForm,
                MathScore = MathScore,
                RussianScore = RussianScore,
                InformaticsScore = InformaticsScore
            };
        }
    }
}
