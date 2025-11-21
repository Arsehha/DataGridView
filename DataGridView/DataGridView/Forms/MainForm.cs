
using DataGridView.Entities;
using DataGridView.Services;
using DataGridViewProject.Infrastructure;

namespace DataGridView.Forms
{
    /// <summary>
    /// Форма с информацией об абитуриентах
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ApplicantService applicantService;
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainForm(ApplicantService applicantService)
        {
            this.applicantService = applicantService;
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            UpdateBindingSources();

            ConfigureColumns();
            _ = RefreshStats();
        }

        private async Task UpdateBindingSources()
        {
            var applicants = await applicantService.GetAll(CancellationToken.None);
            bindingSource.DataSource = applicants.ToList();
            dataGridView.DataSource = bindingSource;
            await RefreshStats();
        }

        private void ConfigureColumns()
        {
            FullName.DataPropertyName = nameof(ApplicantModel.FullName);
            Sex.DataPropertyName = nameof(ApplicantModel.Sex);
            DateOfBirth.DataPropertyName = nameof(ApplicantModel.DateOfBirth);
            EducationForm.DataPropertyName = nameof(ApplicantModel.EducationForm);
            MathScore.DataPropertyName = nameof(ApplicantModel.MathScore);
            RussianScore.DataPropertyName = nameof(ApplicantModel.RussianScore);
            InformaticsScore.DataPropertyName = nameof(ApplicantModel.InformaticsScore);
        }

        private async Task RefreshStats()
        {
            toolStripStatusLabelCount.Text = $"Всего студентов: {await applicantService.GetCountStudents(CancellationToken.None)}";
            toolStripStatusLabelHighScores.Text = $"Всего студентов с более 150 баллов: {await applicantService.GetStudentsByMinScore(Constants.MinTotalScore, CancellationToken.None)}";
        }

        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var form = new AddApplicantForm(new ApplicantModel());
            if (form.ShowDialog() == DialogResult.OK)
            {
                await applicantService.Add(form.Applicant, CancellationToken.None);
                await UpdateBindingSources();
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not ApplicantModel selected)
            {
                return;
            }

            var clone = new ApplicantModel
            {
                Id = selected.Id,
                FullName = selected.FullName,
                Sex = selected.Sex,
                DateOfBirth = selected.DateOfBirth,
                EducationForm = selected.EducationForm,
                MathScore = selected.MathScore,
                RussianScore = selected.RussianScore,
                InformaticsScore = selected.InformaticsScore
            };

            var form = new AddApplicantForm(clone);
            if (form.ShowDialog() == DialogResult.OK)
            {
                await applicantService.Update(form.Applicant, CancellationToken.None);
                await UpdateBindingSources();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is Enum enumVal)
            {
                e.Value = enumVal.GetDisplayName();
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "TotalScores"
                && dataGridView.Rows[e.RowIndex].DataBoundItem is ApplicantModel student)
            {
                e.Value = student.MathScore + student.RussianScore + student.InformaticsScore;
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is not ApplicantModel selected)
            {
                return;
            }
            if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await applicantService.Remove(selected.Id, CancellationToken.None);
                await UpdateBindingSources();
            }
        }
    }
}
