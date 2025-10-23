using System.ComponentModel.DataAnnotations;
using DataGridView.Classes;
using DataGridView.Infrastructure;
using DataGridView.Models;

namespace DataGridView.Forms
{
    public partial class AddApplicantForm : Form
    {
        private readonly ApplicantModel targetApplicant;
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public AddApplicantForm(ApplicantModel? sourceApplicant = null)
        {
            InitializeComponent();

            if (sourceApplicant != null)
            {
                targetApplicant = sourceApplicant.Clone();
                buttonSave.Text = "Сохранить";
                Text = "Редактирование абитуриента";

                numericUpDownMathScore.Value = targetApplicant.MathScore;
                numericUpDownRussianScore.Value = targetApplicant.RussianScore;
                numericUpDownInformaticsScore.Value = targetApplicant.InformaticsScore;
            }
            else
            {
                targetApplicant = new ApplicantModel();
                buttonSave.Text = "Добавить";
                Text = "Добавить абитуриента";
            }

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            comboBoxSex.DataSource = Enum.GetValues(typeof(SexType));
            comboBoxEducationForm.DataSource = Enum.GetValues(typeof(EducationType));

            textBoxFullName.AddBinding(x => x.Text, targetApplicant, x => x.FullName, errorProvider);
            comboBoxSex.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.Sex, errorProvider);
            dateTimePickerDateOfBirth.AddBinding(x => x.Value, targetApplicant, x => x.DateOfBirth, errorProvider);
            comboBoxEducationForm.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.EducationForm, errorProvider);

        }

        /// <summary>
        /// Текущий абитуриент
        /// </summary>
        public ApplicantModel CurrentApplicant => targetApplicant;

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить" или "Добавить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            targetApplicant.MathScore = (int)numericUpDownMathScore.Value;
            targetApplicant.RussianScore = (int)numericUpDownRussianScore.Value;
            targetApplicant.InformaticsScore = (int)numericUpDownInformaticsScore.Value;

            errorProvider.Clear();

            bool hasErrors = false;

            if (targetApplicant.Sex == SexType.None)
            {
                errorProvider.SetError(comboBoxSex, "Пол обязателен для заполнения");
                hasErrors = true;
            }

            if (targetApplicant.EducationForm == EducationType.None)
            {
                errorProvider.SetError(comboBoxEducationForm, "Форма обучения обязательна для заполнения");
                hasErrors = true;
            }

            if (hasErrors)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.",
                    "Обязательные поля",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var context = new ValidationContext(targetApplicant);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(targetApplicant, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(ApplicantModel.FullName) => textBoxFullName,
                            nameof(ApplicantModel.Sex) => comboBoxSex,
                            nameof(ApplicantModel.DateOfBirth) => dateTimePickerDateOfBirth,
                            nameof(ApplicantModel.EducationForm) => comboBoxEducationForm,
                            nameof(ApplicantModel.MathScore) => numericUpDownMathScore,
                            nameof(ApplicantModel.RussianScore) => numericUpDownRussianScore,
                            nameof(ApplicantModel.InformaticsScore) => numericUpDownInformaticsScore,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }

                MessageBox.Show("Пожалуйста, исправьте ошибки в форме перед сохранением.",
                    "Ошибки валидации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
