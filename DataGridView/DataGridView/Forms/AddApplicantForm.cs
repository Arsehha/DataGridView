using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using DataGridView.Entities;
using DataGridView.Entities.Enums;
using DataGridView.Services;
using DataGridViewProject.Infrastructure;

namespace DataGridView.Forms
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
            comboBoxEducationForm.DataSource = Enum.GetValues(typeof(EducationType))
                .Cast<EducationType>()
                .Select(g => new { Value = g, Name = g.GetDisplayName() })
                .ToArray();
            comboBoxEducationForm.DisplayMember = "Name";
            comboBoxEducationForm.ValueMember = "Value";

            comboBoxSex.DataSource = Enum.GetValues(typeof(SexType))
                .Cast<SexType>()
                .Select(g => new { Value = g, Name = g.GetDisplayName() })
                .ToArray();
            comboBoxSex.DisplayMember = "Name";
            comboBoxSex.ValueMember = "Value";

            textBoxFullName.AddBinding(x => x.Text, Applicant, x => x.FullName, errorProvider);
            comboBoxSex.AddBinding(x => x.Text, Applicant, x => x.Sex, errorProvider);
            comboBoxEducationForm.AddBinding(x => x.Text, Applicant, x => x.EducationForm, errorProvider);
            dateTimePickerDateOfBirth.AddBinding(x => x.Text, Applicant, x => x.DateOfBirth, errorProvider);
            numericUpDownMathScore.AddBinding(x => x.Value, Applicant, x => x.MathScore, errorProvider);
            numericUpDownRussianScore.AddBinding(x => x.Value, Applicant, x => x.RussianScore, errorProvider);
            numericUpDownInformaticsScore.AddBinding(x => x.Value, Applicant, x => x.InformaticsScore, errorProvider);
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
