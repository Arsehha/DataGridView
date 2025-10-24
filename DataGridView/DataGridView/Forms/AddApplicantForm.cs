using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using DataGridView.Classes;
using DataGridView.Infrastructure;
using DataGridView.Models;

namespace DataGridView.Forms
{
    public partial class AddApplicantForm : Form
    {
        private readonly ApplicantModel targetApplicant;
        private readonly ErrorProvider errorProvider = new();

        public AddApplicantForm(ApplicantModel? sourceApplicant = null)
        {
            InitializeComponent();

            if (sourceApplicant != null)
            {
                targetApplicant = sourceApplicant.Clone();
                Text = "Редактирование абитуриента";
                buttonSave.Text = "Сохранить";
            }
            else
            {
                targetApplicant = new ApplicantModel();
                Text = "Добавить абитуриента";
                buttonSave.Text = "Добавить";
            }

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            comboBoxSex.DataSource = Enum.GetValues(typeof(SexType));
            comboBoxEducationForm.DataSource = Enum.GetValues(typeof(EducationType));

            textBoxFullName.AddBinding(x => x.Text, targetApplicant, x => x.FullName, errorProvider);
            comboBoxSex.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.Sex, errorProvider);
            dateTimePickerDateOfBirth.AddBinding(x => x.Value, targetApplicant, x => x.DateOfBirth, errorProvider);
            comboBoxEducationForm.AddBinding(x => x.SelectedItem!, targetApplicant, x => x.EducationForm, errorProvider);
            numericUpDownMathScore.AddBinding(x => x.Value, targetApplicant, x => x.MathScore, errorProvider);
            numericUpDownRussianScore.AddBinding(x => x.Value, targetApplicant, x => x.RussianScore, errorProvider);
            numericUpDownInformaticsScore.AddBinding(x => x.Value, targetApplicant, x => x.InformaticsScore, errorProvider);
        }

        public ApplicantModel CurrentApplicant => targetApplicant;

        private void buttonSave_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме.",
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
