using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataGridView.Classes;
using DataGridView.Models;

namespace DataGridView.Forms
{
    public partial class MainForm : Form
    {
        private readonly List<ApplicantModel> applicants;
        private readonly BindingSource bindingSource = new();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            applicants = new List<ApplicantModel>();

            applicants.Add(new ApplicantModel
            {
                Id = Guid.NewGuid(),
                FullName = "Иванов Иван Иванович",
                Sex = SexType.Male,
                DateOfBirth = new DateTime(2005, 3, 15),
                EducationForm = EducationType.FullTime,
                MathScore = 85,
                RussianScore = 90,
                InformaticsScore = 95
            });

            applicants.Add(new ApplicantModel
            {
                Id = Guid.NewGuid(),
                FullName = "Петрова Анна Сергеевна",
                Sex = SexType.Female,
                DateOfBirth = new DateTime(2004, 7, 22),
                EducationForm = EducationType.PartTime,
                MathScore = 78,
                RussianScore = 88,
                InformaticsScore = 82
            });

            applicants.Add(new ApplicantModel
            {
                Id = Guid.NewGuid(),
                FullName = "Сидоров Дмитрий Алексеевич",
                Sex = SexType.Male,
                DateOfBirth = new DateTime(2005, 1, 10),
                EducationForm = EducationType.PartTime,
                MathScore = 92,
                RussianScore = 95,
                InformaticsScore = 98
            });

            SetStatistic();

            FullName.DataPropertyName = nameof(ApplicantModel.FullName);
            Sex.DataPropertyName = nameof(ApplicantModel.Sex);
            DateOfBirth.DataPropertyName = nameof(ApplicantModel.DateOfBirth);
            EducationForm.DataPropertyName = nameof(ApplicantModel.EducationForm);
            MathScore.DataPropertyName = nameof(ApplicantModel.MathScore);
            RussianScore.DataPropertyName = nameof(ApplicantModel.RussianScore);
            InformaticsScore.DataPropertyName = nameof(ApplicantModel.InformaticsScore);
            TotalScore.DataPropertyName = nameof(ApplicantModel.TotalScore);

            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;

            bindingSource.DataSource = applicants;
            dataGridView.DataSource = bindingSource;
        }

        /// <summary>
        /// Форматирование данных в ячейке
        /// </summary>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView.Columns[e.ColumnIndex];
            var applicant = (ApplicantModel)dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (applicant == null)
            {
                return;
            }

            if (col.DataPropertyName == nameof(ApplicantModel.Sex))
            {
                e.Value = applicant.Sex switch
                {
                    SexType.Male => "Мужской",
                    SexType.Female => "Женский",
                    _ => "Не указан"
                };
                e.FormattingApplied = true;
            }
            else if (col.DataPropertyName == nameof(ApplicantModel.EducationForm))
            {
                e.Value = applicant.EducationForm switch
                {
                    EducationType.FullTime => "Очное",
                    EducationType.FullTimeAndPartTime => "Очно-заочное",
                    EducationType.PartTime => "Заочное",
                    _ => "Не выбрано"
                };
                e.FormattingApplied = true;
            }
            else if (col.DataPropertyName == nameof(ApplicantModel.DateOfBirth))
            {
                if (e.Value is DateTime date)
                {
                    e.Value = date.ToShortDateString();
                    e.FormattingApplied = true;
                }
            }
            else if (col.DataPropertyName == nameof(ApplicantModel.TotalScore))
            {
                if (e.Value is int total)
                {
                    e.Value = $"{total} баллов";
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Открытие формы добавления записи
        /// </summary>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddApplicantForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                applicants.Add(addForm.CurrentApplicant);
                OnUpdate();
                MessageBox.Show("Абитуриент успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Открытие формы редактирования записи
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedApplicant = (ApplicantModel)dataGridView.SelectedRows[0].DataBoundItem;
            var selectedIndex = applicants.IndexOf(selectedApplicant);

            var editForm = new AddApplicantForm(selectedApplicant);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (selectedIndex >= 0 && selectedIndex < applicants.Count)
                {
                    applicants[selectedIndex] = editForm.CurrentApplicant;
                    OnUpdate();
                    MessageBox.Show("Абитуриент успешно обновлён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абитуриента для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var applicant = (ApplicantModel)dataGridView.SelectedRows[0].DataBoundItem;
            var target = applicants.FirstOrDefault(x => x.Id == applicant.Id);

            if (target != null &&
                MessageBox.Show($"Вы действительно желаете удалить абитуриента '{target.FullName}'?",
                    "Удаление абитуриента",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                applicants.Remove(target);
                OnUpdate();
            }
        }

        /// <summary>
        /// Данные в statusStrip
        /// </summary>
        private void SetStatistic()
        {
            var totalApplicants = applicants.Count;
            var highScorers = applicants.Count(a => a.TotalScore > 150);

            toolStripStatusLabelCount.Text = $"Всего абитуриентов: {totalApplicants}";
            toolStripStatusLabelHighScores.Text = $"Набрали >150 баллов: {highScorers}";
        }

        /// <summary>
        /// Обновление данных в таблице
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            dataGridView.Refresh();
            SetStatistic();
        }
    }
}
