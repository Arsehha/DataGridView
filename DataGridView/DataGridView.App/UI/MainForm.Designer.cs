namespace DataGridView.App.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            statusStrip = new StatusStrip();
            toolStripStatusLabelCount = new ToolStripStatusLabel();
            toolStripStatusLabelHighScores = new ToolStripStatusLabel();
            dataGridView = new System.Windows.Forms.DataGridView();
            FullName = new DataGridViewTextBoxColumn();
            Sex = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            EducationForm = new DataGridViewTextBoxColumn();
            MathScore = new DataGridViewTextBoxColumn();
            RussianScore = new DataGridViewTextBoxColumn();
            InformaticsScore = new DataGridViewTextBoxColumn();
            TotalScore = new DataGridViewTextBoxColumn();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(135, 22);
            toolStripButtonAdd.Text = "Добавить абитуриента";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(163, 22);
            toolStripButtonEdit.Text = "Редактировать абитуриента";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(135, 22);
            toolStripButtonDelete.Text = "Удаление абитуриента";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelCount, toolStripStatusLabelHighScores });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            toolStripStatusLabelCount.Size = new Size(145, 17);
            toolStripStatusLabelCount.Text = "toolStripStatusLabelCount";
            // 
            // toolStripStatusLabelHighScores
            // 
            toolStripStatusLabelHighScores.Name = "toolStripStatusLabelHighScores";
            toolStripStatusLabelHighScores.Size = new Size(118, 17);
            toolStripStatusLabelHighScores.Text = "toolStripStatusLabel2";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { FullName, Sex, DateOfBirth, EducationForm, MathScore, RussianScore, InformaticsScore, TotalScore });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 25);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(800, 403);
            dataGridView.TabIndex = 2;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // FullName
            // 
            FullName.HeaderText = "ФИО";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            // 
            // Sex
            // 
            Sex.HeaderText = "Пол";
            Sex.Name = "Sex";
            Sex.ReadOnly = true;
            Sex.Resizable = DataGridViewTriState.True;
            Sex.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Дата рождения";
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.ReadOnly = true;
            // 
            // EducationForm
            // 
            EducationForm.HeaderText = "Форма обучения";
            EducationForm.Name = "EducationForm";
            EducationForm.ReadOnly = true;
            EducationForm.Resizable = DataGridViewTriState.True;
            EducationForm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // MathScore
            // 
            MathScore.HeaderText = "Баллы ЕГЭ по математике";
            MathScore.Name = "MathScore";
            MathScore.ReadOnly = true;
            // 
            // RussianScore
            // 
            RussianScore.HeaderText = "Баллы ЕГЭ по русскому";
            RussianScore.Name = "RussianScore";
            RussianScore.ReadOnly = true;
            // 
            // InformaticsScore
            // 
            InformaticsScore.HeaderText = "Баллы ЕГЭ по информатике";
            InformaticsScore.Name = "InformaticsScore";
            InformaticsScore.ReadOnly = true;
            // 
            // TotalScore
            // 
            TotalScore.HeaderText = "Общая сумма баллов";
            TotalScore.Name = "TotalScore";
            TotalScore.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Name = "MainForm";
            Text = "Управление абитуриентами";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.DataGridView dataGridView;
        private ToolStripStatusLabel toolStripStatusLabelCount;
        private ToolStripStatusLabel toolStripStatusLabelHighScores;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn EducationForm;
        private DataGridViewTextBoxColumn MathScore;
        private DataGridViewTextBoxColumn RussianScore;
        private DataGridViewTextBoxColumn InformaticsScore;
        private DataGridViewTextBoxColumn TotalScore;
    }
}
