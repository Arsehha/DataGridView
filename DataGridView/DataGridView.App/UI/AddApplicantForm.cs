using System.ComponentModel.DataAnnotations;
using DataGridView.Entities;
using DataGridView.Entities.Enums;
using DataGridViewProject.Infrastructure;

namespace DataGridView.App.UI
{
    /// <summary>
    /// Форма редактирования студентов
    /// </summary>
    public partial class AddApplicantForm : Form
    {
        /// <summary>
        /// Текущий студент
        /// </summary>
        public ApplicantModel Applicant;

        /// <summary>
        /// Инициализировать новый экземпляр
        /// </summary>
        public AddApplicantForm(ApplicantModel student)
        {
            InitializeComponent();
            Applicant = student;
            InitBindings();
        }

        private void InitBindings()
        {
            // Источник данных для формы обучения
            comboBoxEducationForm.DataSource = Enum
                .GetValues(typeof(EducationType))
                .Cast<EducationType>()
                .Select(x => new { Value = x, Name = x.GetDisplayName() })
                .ToList();

            comboBoxEducationForm.DisplayMember = "Name";
            comboBoxEducationForm.ValueMember = "Value";

            // Источник данных для пола
            comboBoxSex.DataSource = Enum
                .GetValues(typeof(SexType))
                .Cast<SexType>()
                .Select(x => new { Value = x, Name = x.GetDisplayName() })
                .ToList();

            comboBoxSex.DisplayMember = "Name";
            comboBoxSex.ValueMember = "Value";

            // Привязки строковых и числовых полей
            textBoxFullName.AddBinding(x => x.Text, Applicant, x => x.FullName, errorProvider);

            numericUpDownMathScore.AddBinding(x => x.Value, Applicant, x => x.MathScore, errorProvider);
            numericUpDownRussianScore.AddBinding(x => x.Value, Applicant, x => x.RussianScore, errorProvider);
            numericUpDownInformaticsScore.AddBinding(x => x.Value, Applicant, x => x.InformaticsScore, errorProvider);

            comboBoxSex.DataBindings.Add(
                new Binding("SelectedValue", Applicant, nameof(Applicant.Sex), true, DataSourceUpdateMode.OnPropertyChanged));

            comboBoxEducationForm.DataBindings.Add(
                new Binding("SelectedValue", Applicant, nameof(Applicant.EducationForm), true, DataSourceUpdateMode.OnPropertyChanged));

            dateTimePickerDateOfBirth.DataBindings.Add(
                new Binding("Value", Applicant, nameof(Applicant.DateOfBirth), true, DataSourceUpdateMode.OnPropertyChanged));

            if (Applicant.DateOfBirth < dateTimePickerDateOfBirth.MinDate)
            {
                dateTimePickerDateOfBirth.Value = DateTime.Now.AddYears(-18);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Applicant.DateOfBirth = Applicant.DateOfBirth.Date;

            var context = new ValidationContext(Applicant);
            var results = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(Applicant, context, results, true);
            if (!valid)
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(Applicant.FullName) => textBoxFullName,
                            nameof(Applicant.Sex) => comboBoxSex,
                            nameof(Applicant.DateOfBirth) => dateTimePickerDateOfBirth,
                            nameof(Applicant.EducationForm) => comboBoxEducationForm,
                            nameof(Applicant.MathScore) => numericUpDownMathScore,
                            nameof(Applicant.RussianScore) => numericUpDownRussianScore,
                            nameof(Applicant.InformaticsScore) => numericUpDownInformaticsScore,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }

                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
