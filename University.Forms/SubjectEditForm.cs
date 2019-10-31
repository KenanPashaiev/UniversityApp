using System;
using System.Data;
using System.Windows.Forms;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Repositories;
using UniversityApp.Forms.Validation;

namespace UniversityApp.Forms
{
    public partial class SubjectEditForm : Form
    {
        private readonly DataAccessProvider _dataProvider;
        private readonly int _universityId;

        public SubjectEditForm(int universityId)
        {
            InitializeComponent();
            _dataProvider = new DataAccessProvider();
            _universityId = universityId;
            RefreshForm();
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            var subjectRepository = new SubjectRepository();

            var subjectName = addSubjectNameTextBox.Text;
            var subject = new Subject(subjectName, _universityId);

            if (!SubjectValidation.IsValidSubject(subject))
            {
                return;
            }

            subjectRepository.Create(subject);
            RefreshForm();
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {
            var teacherRepository = new TeacherRepository();

            var name = addTeacherNameTextBox.Text;
            var surname = addTeacherSurnameTextBox.Text;
            var age = (int)addTeacherAgeNumericUpDown.Value;
            var teacher = new Teacher(name, surname, age);

            if(!TeacherValidation.IsValidTeacher(teacher))
            {
                return;
            }

            teacherRepository.Create(teacher);
            RefreshForm();
        }

        private void SetTeacherSubjectButton_Click(object sender, EventArgs e)
        {
            var subjectRepository = new SubjectRepository();
            var expression = $"SubjectName = \'{selectSubjectComboBox.SelectedItem}\'";
            var subjectId = subjectRepository.FindAll().Select(expression)[0]["SubjectID"];

            var teacherRepository = new TeacherRepository();
            var initials = selectTeacherComboBox.SelectedItem.ToString().Split();
            expression = $"TeacherName = \'{initials[0]}\' and TeacherSurname = \'{initials[1]}\'";
            var teacherId = teacherRepository.FindAll().Select(expression)[0]["TeacherID"];

            _dataProvider.ExecuteNonQuery($"UPDATE Subjects SET TeacherID = {teacherId} WHERE SubjectID = {subjectId};");
            _dataProvider.ExecuteNonQuery($"UPDATE Teachers SET SubjectID = {subjectId} WHERE TeacherID = {teacherId};");

            selectSubjectComboBox.Text = string.Empty;
            selectTeacherComboBox.Text = string.Empty;
            RefreshForm();
        }

        private void RefreshForm()
        {
            subjectDataGrid.DataSource = _dataProvider.ExecuteQuery($"SELECT * FROM Subjects WHERE UniversityID = {_universityId}");
            teacherDataGrid.DataSource = _dataProvider.ExecuteQuery($"SELECT * FROM Teachers");

            selectSubjectComboBox.Items.Clear();
            selectTeacherComboBox.Items.Clear();

            DataTable subjectList = _dataProvider.ExecuteQuery("SELECT SubjectName FROM Subjects WHERE TeacherID IS NULL AND UniversityID = " + _universityId);
            for (int i = 0; i < subjectList.Rows.Count; i++)
            {
                selectSubjectComboBox.Items.Add(subjectList.Rows[i].Field<string>(0));
            }

            DataTable teacherList = _dataProvider.ExecuteQuery("SELECT TeacherName, TeacherSurname FROM Teachers WHERE SubjectID IS NULL");
            for (int i = 0; i < teacherList.Rows.Count; i++)
            {
                selectTeacherComboBox.Items.Add(teacherList.Rows[i].Field<string>(0) + " " + teacherList.Rows[i].Field<string>(1));
            }
        }
    }
}
