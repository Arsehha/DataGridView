namespace DataGridView.Forms
{
    partial class AddApplicantForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            buttonSave = new Button();
            button2 = new Button();
            numericUpDownMathScore = new NumericUpDown();
            numericUpDownRussianScore = new NumericUpDown();
            numericUpDownInformaticsScore = new NumericUpDown();
            comboBoxSex = new ComboBox();
            comboBoxEducationForm = new ComboBox();
            textBoxFullName = new TextBox();
            dateTimePickerDateOfBirth = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMathScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussianScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformaticsScore).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 29);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 59);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Пол";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 90);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 2;
            label3.Text = "Дата рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 121);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 3;
            label4.Text = "Форма обучения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 153);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 4;
            label5.Text = "Баллы по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(46, 184);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 5;
            label6.Text = "Баллы по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 219);
            label7.Name = "label7";
            label7.Size = new Size(139, 15);
            label7.TabIndex = 6;
            label7.Text = "Баллы по информатике";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(128, 255);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 255);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // numericUpDownMathScore
            // 
            numericUpDownMathScore.Location = new Point(188, 151);
            numericUpDownMathScore.Name = "numericUpDownMathScore";
            numericUpDownMathScore.Size = new Size(200, 23);
            numericUpDownMathScore.TabIndex = 9;
            // 
            // numericUpDownRussianScore
            // 
            numericUpDownRussianScore.Location = new Point(188, 182);
            numericUpDownRussianScore.Name = "numericUpDownRussianScore";
            numericUpDownRussianScore.Size = new Size(200, 23);
            numericUpDownRussianScore.TabIndex = 10;
            // 
            // numericUpDownInformaticsScore
            // 
            numericUpDownInformaticsScore.Location = new Point(188, 217);
            numericUpDownInformaticsScore.Name = "numericUpDownInformaticsScore";
            numericUpDownInformaticsScore.Size = new Size(200, 23);
            numericUpDownInformaticsScore.TabIndex = 11;
            // 
            // comboBoxSex
            // 
            comboBoxSex.FormattingEnabled = true;
            comboBoxSex.Location = new Point(188, 56);
            comboBoxSex.Name = "comboBoxSex";
            comboBoxSex.Size = new Size(200, 23);
            comboBoxSex.TabIndex = 12;
            // 
            // comboBoxEducationForm
            // 
            comboBoxEducationForm.FormattingEnabled = true;
            comboBoxEducationForm.Location = new Point(188, 118);
            comboBoxEducationForm.Name = "comboBoxEducationForm";
            comboBoxEducationForm.Size = new Size(200, 23);
            comboBoxEducationForm.TabIndex = 13;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(188, 26);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(200, 23);
            textBoxFullName.TabIndex = 14;
            // 
            // dateTimePickerDateOfBirth
            // 
            dateTimePickerDateOfBirth.Location = new Point(188, 89);
            dateTimePickerDateOfBirth.MaxDate = new DateTime(2025, 10, 23, 0, 0, 0, 0);
            dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
            dateTimePickerDateOfBirth.Size = new Size(200, 23);
            dateTimePickerDateOfBirth.TabIndex = 15;
            dateTimePickerDateOfBirth.Value = new DateTime(2025, 10, 23, 0, 0, 0, 0);
            // 
            // AddApplicantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 321);
            Controls.Add(dateTimePickerDateOfBirth);
            Controls.Add(textBoxFullName);
            Controls.Add(comboBoxEducationForm);
            Controls.Add(comboBoxSex);
            Controls.Add(numericUpDownInformaticsScore);
            Controls.Add(numericUpDownRussianScore);
            Controls.Add(numericUpDownMathScore);
            Controls.Add(button2);
            Controls.Add(buttonSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddApplicantForm";
            Text = "Абитуриент";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMathScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRussianScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInformaticsScore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button buttonSave;
        private Button button2;
        private NumericUpDown numericUpDownMathScore;
        private NumericUpDown numericUpDownRussianScore;
        private NumericUpDown numericUpDownInformaticsScore;
        private ComboBox comboBoxSex;
        private ComboBox comboBoxEducationForm;
        private TextBox textBoxFullName;
        private DateTimePicker dateTimePickerDateOfBirth;
    }
}