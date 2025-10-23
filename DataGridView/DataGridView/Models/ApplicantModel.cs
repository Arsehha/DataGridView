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
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} должно быть от {2} до {1} символов")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Пол
        /// </summary>
        [Display(Name = "Пол")]
        [Required(ErrorMessage = "{0} обязателен для выбора")]
        public SexType Sex { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "{0} обязательна для заполнения")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Форма обучения
        /// </summary>
        [Display(Name = "Форма обучения")]
        [Required(ErrorMessage = "{0} обязателен для выбора")]
        public EducationType EducationForm { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по математике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по математике")]
        [Range(0, 100, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int MathScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по русскому языку
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по русскому языку")]
        [Range(0, 100, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int RussianScore { get; set; }

        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Display(Name = "Баллы ЕГЭ по информатике")]
        [Range(0, 100, ErrorMessage = "{0} должно быть от {1} до {2}")]
        public int InformaticsScore { get; set; }

        /// <summary>
        /// Общая сумма баллов
        /// </summary>
        [Display(Name = "Общая сумма баллов")]
        public int TotalScore
        {
            get
            {
                return MathScore + RussianScore + InformaticsScore;
            }
        }

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
