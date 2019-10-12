namespace UniversityApp.Forms
{
    partial class SubjectEditForm
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
            this.subjectDataGrid = new System.Windows.Forms.DataGridView();
            this.teacherDataGrid = new System.Windows.Forms.DataGridView();
            this.addTeacherAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.addTeacherSurnameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addTeacherNameTextBox = new System.Windows.Forms.TextBox();
            this.addTeacherButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addSubjectNameTextBox = new System.Windows.Forms.TextBox();
            this.addSubjectButton = new System.Windows.Forms.Button();
            this.selectSubjectComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectTeacherComboBox = new System.Windows.Forms.ComboBox();
            this.setTeacherSubjectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacherAgeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectDataGrid
            // 
            this.subjectDataGrid.AllowUserToAddRows = false;
            this.subjectDataGrid.AllowUserToDeleteRows = false;
            this.subjectDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectDataGrid.Location = new System.Drawing.Point(485, 11);
            this.subjectDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.subjectDataGrid.Name = "subjectDataGrid";
            this.subjectDataGrid.RowHeadersWidth = 82;
            this.subjectDataGrid.RowTemplate.Height = 33;
            this.subjectDataGrid.Size = new System.Drawing.Size(863, 349);
            this.subjectDataGrid.TabIndex = 0;
            // 
            // teacherDataGrid
            // 
            this.teacherDataGrid.AllowUserToAddRows = false;
            this.teacherDataGrid.AllowUserToDeleteRows = false;
            this.teacherDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teacherDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherDataGrid.Location = new System.Drawing.Point(485, 371);
            this.teacherDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.teacherDataGrid.Name = "teacherDataGrid";
            this.teacherDataGrid.RowHeadersWidth = 82;
            this.teacherDataGrid.RowTemplate.Height = 33;
            this.teacherDataGrid.Size = new System.Drawing.Size(863, 340);
            this.teacherDataGrid.TabIndex = 1;
            // 
            // addTeacherAgeNumericUpDown
            // 
            this.addTeacherAgeNumericUpDown.Location = new System.Drawing.Point(165, 278);
            this.addTeacherAgeNumericUpDown.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.addTeacherAgeNumericUpDown.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.addTeacherAgeNumericUpDown.Name = "addTeacherAgeNumericUpDown";
            this.addTeacherAgeNumericUpDown.Size = new System.Drawing.Size(273, 26);
            this.addTeacherAgeNumericUpDown.TabIndex = 36;
            this.addTeacherAgeNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Teacher Surname";
            // 
            // addTeacherSurnameTextBox
            // 
            this.addTeacherSurnameTextBox.Location = new System.Drawing.Point(165, 214);
            this.addTeacherSurnameTextBox.Name = "addTeacherSurnameTextBox";
            this.addTeacherSurnameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addTeacherSurnameTextBox.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Teacher Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Teacher Name";
            // 
            // addTeacherNameTextBox
            // 
            this.addTeacherNameTextBox.Location = new System.Drawing.Point(165, 153);
            this.addTeacherNameTextBox.Name = "addTeacherNameTextBox";
            this.addTeacherNameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addTeacherNameTextBox.TabIndex = 31;
            // 
            // addTeacherButton
            // 
            this.addTeacherButton.Location = new System.Drawing.Point(129, 340);
            this.addTeacherButton.Name = "addTeacherButton";
            this.addTeacherButton.Size = new System.Drawing.Size(147, 43);
            this.addTeacherButton.TabIndex = 30;
            this.addTeacherButton.Text = " Add Teacher";
            this.addTeacherButton.UseVisualStyleBackColor = true;
            this.addTeacherButton.Click += new System.EventHandler(this.AddTeacherButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Subject Name";
            // 
            // addSubjectNameTextBox
            // 
            this.addSubjectNameTextBox.Location = new System.Drawing.Point(165, 27);
            this.addSubjectNameTextBox.Name = "addSubjectNameTextBox";
            this.addSubjectNameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addSubjectNameTextBox.TabIndex = 28;
            // 
            // addSubjectButton
            // 
            this.addSubjectButton.Location = new System.Drawing.Point(129, 76);
            this.addSubjectButton.Name = "addSubjectButton";
            this.addSubjectButton.Size = new System.Drawing.Size(147, 43);
            this.addSubjectButton.TabIndex = 27;
            this.addSubjectButton.Text = "Add Subject";
            this.addSubjectButton.UseVisualStyleBackColor = true;
            this.addSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
            // 
            // selectSubjectComboBox
            // 
            this.selectSubjectComboBox.FormattingEnabled = true;
            this.selectSubjectComboBox.Location = new System.Drawing.Point(166, 422);
            this.selectSubjectComboBox.Name = "selectSubjectComboBox";
            this.selectSubjectComboBox.Size = new System.Drawing.Size(273, 28);
            this.selectSubjectComboBox.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Teacher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Subject";
            // 
            // selectTeacherComboBox
            // 
            this.selectTeacherComboBox.FormattingEnabled = true;
            this.selectTeacherComboBox.Location = new System.Drawing.Point(166, 489);
            this.selectTeacherComboBox.Name = "selectTeacherComboBox";
            this.selectTeacherComboBox.Size = new System.Drawing.Size(273, 28);
            this.selectTeacherComboBox.TabIndex = 40;
            // 
            // setTeacherSubjectButton
            // 
            this.setTeacherSubjectButton.Location = new System.Drawing.Point(129, 547);
            this.setTeacherSubjectButton.Name = "setTeacherSubjectButton";
            this.setTeacherSubjectButton.Size = new System.Drawing.Size(147, 43);
            this.setTeacherSubjectButton.TabIndex = 41;
            this.setTeacherSubjectButton.Text = "Set";
            this.setTeacherSubjectButton.UseVisualStyleBackColor = true;
            this.setTeacherSubjectButton.Click += new System.EventHandler(this.SetTeacherSubjectButton_Click);
            // 
            // SubjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1359, 722);
            this.Controls.Add(this.setTeacherSubjectButton);
            this.Controls.Add(this.selectTeacherComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectSubjectComboBox);
            this.Controls.Add(this.addTeacherAgeNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addTeacherSurnameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addTeacherNameTextBox);
            this.Controls.Add(this.addTeacherButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addSubjectNameTextBox);
            this.Controls.Add(this.addSubjectButton);
            this.Controls.Add(this.teacherDataGrid);
            this.Controls.Add(this.subjectDataGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SubjectEditForm";
            this.Text = "SubjectEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addTeacherAgeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView subjectDataGrid;
        private System.Windows.Forms.DataGridView teacherDataGrid;
        private System.Windows.Forms.NumericUpDown addTeacherAgeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addTeacherSurnameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addTeacherNameTextBox;
        private System.Windows.Forms.Button addTeacherButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addSubjectNameTextBox;
        private System.Windows.Forms.Button addSubjectButton;
        private System.Windows.Forms.ComboBox selectSubjectComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox selectTeacherComboBox;
        private System.Windows.Forms.Button setTeacherSubjectButton;
    }
}