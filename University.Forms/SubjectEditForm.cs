using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UniversityApp.Forms
{
    public partial class SubjectEditForm : Form
    {
        private readonly int _universityId;

        public SubjectEditForm(int universityId)
        {
            InitializeComponent();
            _universityId = universityId;
            RefreshForm();
        }

        private DataTable SelectQuery(string statement)
        {
            DataTable table = new DataTable();
            var connectionString = "Data Source=DESKTOP-I35U24I;Initial Catalog=UniversitiesDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter(statement, connection);

                adapter.Fill(table);
            }

            return table;
        }

        private void NonQuery(string statement)
        {
            var connectionString = "Data Source=DESKTOP-I35U24I;Initial Catalog=UniversitiesDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(statement, connection);
                command.ExecuteNonQuery();
            }
        }

        private void AddSubjectButton_Click(object sender, EventArgs e)
        {
            var subjectName = addSubjectNameTextBox.Text;

            if (!IsValidSubject(subjectName))
            {
                return;
            }

            NonQuery("INSERT INTO Subjects (SubjectName, UniversityID) " +
                        $"values ('{subjectName}', {_universityId} )");

            RefreshForm();
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {
            var name = addTeacherNameTextBox.Text;
            var surname = addTeacherSurnameTextBox.Text;
            var age = (int)addTeacherAgeNumericUpDown.Value;

            if(!IsValidTeacher(name, surname, age))
            {
                return;
            }

            NonQuery("INSERT INTO Teachers (TeacherName, TeacherSurname, TeacherAge) " +
                        $"values ('{name}', '{surname}', {age} )");

            RefreshForm();
        }

        private void SetTeacherSubjectButton_Click(object sender, EventArgs e)
        {
            var table = SelectQuery("SELECT * FROM Subjects WHERE UniversityID = " + _universityId);
            var subjectName = selectSubjectComboBox.Text;
            var row = table.Select($"SubjectName = '{subjectName}' ").Single();
            var subjectId = row.Field<int>("SubjectID");

            table = SelectQuery("SELECT * FROM Teachers");
            var teacherName = selectTeacherComboBox.Text.Split(null)[0];
            var teacherSurname = selectTeacherComboBox.Text.Split(null)[1];
            row = table.Select($"TeacherName = '{teacherName}' AND TeacherSurname = '{teacherSurname}'").Single();
            var teacherId = row.Field<int>("TeacherID");

            NonQuery($"UPDATE Subjects SET TeacherID = {teacherId} WHERE SubjectID = {subjectId};");
            NonQuery($"UPDATE Teachers SET SubjectID = {subjectId} WHERE TeacherID = {teacherId};");

            selectSubjectComboBox.Text = string.Empty;
            selectTeacherComboBox.Text = string.Empty;
            RefreshForm();
        }

        private bool IsValidSubject(string subjectName)
        {
            DataTable dataTable = SelectQuery($"SELECT TOP 1 SubjectName FROM Subjects WHERE SubjectName = \'{subjectName}\';");
            DataRow[] dataRow = dataTable.Select();

            if(dataRow.Length != 0)
            {
                MessageBox.Show("There is already a subject with that name");
                return false;
            }
            else if(subjectName == string.Empty)
            {
                MessageBox.Show("Subject name textbox is empty");
                return false;
            }

            return true;
        }

        private bool IsValidTeacher(string name, string surname, int age)
        {
            DataTable dataTable = SelectQuery($"SELECT TOP 1 * FROM Teachers WHERE TeacherName = \'{name}\' and TeacherSurname = \'{surname}\';");
            DataRow[] dataRow = dataTable.Select();

            if (dataRow.Length != 0)
            {
                MessageBox.Show("There is already a teacher with that name and surname");
                return false;
            }

            if (name != string.Empty && surname != string.Empty) return true;
            MessageBox.Show("Name or surname textbox is empty");
            return false;


        }

        private void RefreshForm()
        {
            subjectDataGrid.DataSource = SelectQuery($"SELECT * FROM Subjects WHERE UniversityID = {_universityId}");
            teacherDataGrid.DataSource = SelectQuery("SELECT * FROM Teachers");

            selectSubjectComboBox.Items.Clear();
            selectTeacherComboBox.Items.Clear();

            DataTable subjectList = SelectQuery("SELECT SubjectName FROM Subjects WHERE TeacherID IS NULL AND UniversityID = " + _universityId);
            for (int i = 0; i < subjectList.Rows.Count; i++)
            {
                selectSubjectComboBox.Items.Add(subjectList.Rows[i].Field<string>(0));
            }

            DataTable teacherList = SelectQuery("SELECT TeacherName, TeacherSurname FROM Teachers WHERE SubjectID IS NULL");
            for (int i = 0; i < teacherList.Rows.Count; i++)
            {
                selectTeacherComboBox.Items.Add(teacherList.Rows[i].Field<string>(0) + " " + teacherList.Rows[i].Field<string>(1));
            }
        }
    }
}
