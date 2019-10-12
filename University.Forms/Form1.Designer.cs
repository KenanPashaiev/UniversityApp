namespace UniversityApp.Forms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.universityDataGridView = new System.Windows.Forms.DataGridView();
            this.addUniversityButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.addUniversityNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addStudentNameTextBox = new System.Windows.Forms.TextBox();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addStudentSurnameTextBox = new System.Windows.Forms.TextBox();
            this.addStudentAgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.subjectsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.addRecordButton = new System.Windows.Forms.Button();
            this.subjectsComboBox = new System.Windows.Forms.ComboBox();
            this.editSubjectsButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.universityDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStudentAgeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsNumeric)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // universityDataGridView
            // 
            this.universityDataGridView.AllowUserToAddRows = false;
            this.universityDataGridView.AllowUserToDeleteRows = false;
            this.universityDataGridView.AllowUserToResizeColumns = false;
            this.universityDataGridView.AllowUserToResizeRows = false;
            this.universityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.universityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.universityDataGridView.Location = new System.Drawing.Point(471, 93);
            this.universityDataGridView.Name = "universityDataGridView";
            this.universityDataGridView.ReadOnly = true;
            this.universityDataGridView.RowHeadersWidth = 62;
            this.universityDataGridView.RowTemplate.Height = 28;
            this.universityDataGridView.Size = new System.Drawing.Size(1415, 919);
            this.universityDataGridView.TabIndex = 0;
            this.universityDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UniversityDataGridView_CellMouseClick);
            // 
            // addUniversityButton
            // 
            this.addUniversityButton.Location = new System.Drawing.Point(113, 139);
            this.addUniversityButton.Name = "addUniversityButton";
            this.addUniversityButton.Size = new System.Drawing.Size(147, 43);
            this.addUniversityButton.TabIndex = 1;
            this.addUniversityButton.Text = "Add University";
            this.addUniversityButton.UseVisualStyleBackColor = true;
            this.addUniversityButton.Click += new System.EventHandler(this.AddUniversityButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(1728, 34);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(158, 43);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // addUniversityNameTextBox
            // 
            this.addUniversityNameTextBox.Location = new System.Drawing.Point(149, 93);
            this.addUniversityNameTextBox.Name = "addUniversityNameTextBox";
            this.addUniversityNameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addUniversityNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "University Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Group Name";
            // 
            // addGroupNameTextBox
            // 
            this.addGroupNameTextBox.Location = new System.Drawing.Point(149, 202);
            this.addGroupNameTextBox.Name = "addGroupNameTextBox";
            this.addGroupNameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addGroupNameTextBox.TabIndex = 6;
            // 
            // addGroupButton
            // 
            this.addGroupButton.Location = new System.Drawing.Point(113, 251);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(147, 43);
            this.addGroupButton.TabIndex = 5;
            this.addGroupButton.Text = "Add Group";
            this.addGroupButton.UseVisualStyleBackColor = true;
            this.addGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(471, 34);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(108, 42);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Student Name";
            // 
            // addStudentNameTextBox
            // 
            this.addStudentNameTextBox.Location = new System.Drawing.Point(149, 328);
            this.addStudentNameTextBox.Name = "addStudentNameTextBox";
            this.addStudentNameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addStudentNameTextBox.TabIndex = 10;
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(113, 515);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(147, 43);
            this.addStudentButton.TabIndex = 9;
            this.addStudentButton.Text = "Add Student";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Student Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Student Surname";
            // 
            // addStudentSurnameTextBox
            // 
            this.addStudentSurnameTextBox.Location = new System.Drawing.Point(149, 389);
            this.addStudentSurnameTextBox.Name = "addStudentSurnameTextBox";
            this.addStudentSurnameTextBox.Size = new System.Drawing.Size(273, 26);
            this.addStudentSurnameTextBox.TabIndex = 14;
            // 
            // addStudentAgeNumericUpDown
            // 
            this.addStudentAgeNumericUpDown.Location = new System.Drawing.Point(149, 453);
            this.addStudentAgeNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.addStudentAgeNumericUpDown.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.addStudentAgeNumericUpDown.Name = "addStudentAgeNumericUpDown";
            this.addStudentAgeNumericUpDown.Size = new System.Drawing.Size(273, 26);
            this.addStudentAgeNumericUpDown.TabIndex = 26;
            this.addStudentAgeNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // subjectsNumeric
            // 
            this.subjectsNumeric.Location = new System.Drawing.Point(113, 671);
            this.subjectsNumeric.Name = "subjectsNumeric";
            this.subjectsNumeric.Size = new System.Drawing.Size(273, 26);
            this.subjectsNumeric.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 610);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Subject";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 671);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Mark";
            // 
            // addRecordButton
            // 
            this.addRecordButton.Location = new System.Drawing.Point(113, 732);
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(147, 43);
            this.addRecordButton.TabIndex = 27;
            this.addRecordButton.Text = "Add Record";
            this.addRecordButton.UseVisualStyleBackColor = true;
            this.addRecordButton.Click += new System.EventHandler(this.AddRecordButton_Click);
            // 
            // subjectsComboBox
            // 
            this.subjectsComboBox.FormattingEnabled = true;
            this.subjectsComboBox.Location = new System.Drawing.Point(113, 603);
            this.subjectsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.subjectsComboBox.Name = "subjectsComboBox";
            this.subjectsComboBox.Size = new System.Drawing.Size(273, 28);
            this.subjectsComboBox.TabIndex = 35;
            // 
            // editSubjectsButton
            // 
            this.editSubjectsButton.Location = new System.Drawing.Point(390, 603);
            this.editSubjectsButton.Margin = new System.Windows.Forms.Padding(2);
            this.editSubjectsButton.Name = "editSubjectsButton";
            this.editSubjectsButton.Size = new System.Drawing.Size(64, 32);
            this.editSubjectsButton.TabIndex = 36;
            this.editSubjectsButton.Text = "Edit";
            this.editSubjectsButton.UseVisualStyleBackColor = true;
            this.editSubjectsButton.Click += new System.EventHandler(this.EditSubjectsButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 36);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 928);
            this.Controls.Add(this.editSubjectsButton);
            this.Controls.Add(this.subjectsComboBox);
            this.Controls.Add(this.subjectsNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addRecordButton);
            this.Controls.Add(this.addStudentAgeNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addStudentSurnameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addStudentNameTextBox);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addGroupNameTextBox);
            this.Controls.Add(this.addGroupButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addUniversityNameTextBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.addUniversityButton);
            this.Controls.Add(this.universityDataGridView);
            this.Name = "Form1";
            this.Text = "z";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.universityDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addStudentAgeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsNumeric)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView universityDataGridView;
        private System.Windows.Forms.Button addUniversityButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox addUniversityNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addGroupNameTextBox;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addStudentNameTextBox;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addStudentSurnameTextBox;
        private System.Windows.Forms.NumericUpDown addStudentAgeNumericUpDown;
        private System.Windows.Forms.NumericUpDown subjectsNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addRecordButton;
        private System.Windows.Forms.ComboBox subjectsComboBox;
        private System.Windows.Forms.Button editSubjectsButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

