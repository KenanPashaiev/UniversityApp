using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace UniversityApp.Forms
{
    public enum Inspecting
    {
        Universities,
        Groups,
        Students,
        StudentMarks
    }

    public partial class Form1 : Form
    {
        public Inspecting Inspecting { get; private set; }
        public List<int> InspectingList;
        
        public Form1()
        {
            InitializeComponent();
            Inspecting = Inspecting.Universities;
            InspectingList = new List<int>();
            RefreshUniversitiesList();
            
        }

        private DataTable SelectQuery(string statement)
        {
            DataTable table = new DataTable();
            var connectionString = "Data Source=DESKTOP-I35U24I;Initial Catalog=UniversitiesDatabase;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
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

        ////Adding
        //Adding Button Clicks
        private void AddUniversityButton_Click(object sender, EventArgs e)
        {
            var universityName = addUniversityNameTextBox.Text;

            if (!IsValidUniversity(universityName) && Inspecting != Inspecting.Universities)
            {
                return;
            }

            NonQuery($"INSERT INTO Universities (UniversityName) values ('{universityName}')");

            RefreshUniversitiesList();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            var groupName = addGroupNameTextBox.Text;

            if (!IsValidGroup(groupName))
            {
                return;
            }

            NonQuery("INSERT INTO Groups (GroupName, UniversityID) " +
                        $"values ('{groupName}', {InspectingList.Last()} )");

            RefreshGroupsList(InspectingList.Last());
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            var age = (int)addStudentAgeNumericUpDown.Value;
            var name = addStudentNameTextBox.Text;
            var surname = addStudentSurnameTextBox.Text;

            if (!IsValidStudent(name, surname, age))
            {
                return;
            }

            NonQuery("INSERT INTO Students (StudentName, StudentSurname, StudentAge, GroupID) " +
                        $"values ('{name}', '{surname}', {age}, {InspectingList.Last()} )");

            RefreshStudentsList(InspectingList.Last());
        }

        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            var table = SelectQuery("SELECT * FROM Subjects WHERE UniversityID = " + InspectingList.First());
            DataRow row = table.Select($"SubjectName = \'{subjectsComboBox.Text}\' ").Single();
            var mark = subjectsNumeric.Value;
            var subjectId = row.Field<int>("SubjectID");

            NonQuery("INSERT INTO Records (Mark, StudentID, SubjectID) " +
                        $"values ('{mark}', '{InspectingList.Last()}', {subjectId})");

            RefreshRecordsList(InspectingList.Last());
        }

        //Check add info
        private bool IsValidUniversity(string universityName)
        {
            if (universityName == string.Empty)
            {
                MessageBox.Show("University name textbox is empty");
                return false;
            }

            if (Inspecting != Inspecting.Universities)
            {
                MessageBox.Show("To add a university the university list should be opened");
                return false;
            }

            return true;
        }

        private bool IsValidGroup(string groupName)
        {
            if (groupName == string.Empty)
            {
                MessageBox.Show("Group name textbox is empty");
                return false;
            }

            if (Inspecting != Inspecting.Groups)
            {
                MessageBox.Show("To add group a group list should be opened");
                return false;
            }

            return true;
        }

        private bool IsValidStudent(string name, string surname, int age)
        {
            if (name == string.Empty ||
                surname == string.Empty)
            {
                MessageBox.Show("Name or surname textbox is empty");
                return false;
            }

            if (Inspecting == Inspecting.Students) return true;
            MessageBox.Show("To add student a student list should be opened");
            return false;

        }
        ////

        //Return Back
        private void BackButton_Click(object sender, EventArgs e)
        {
            RefreshUniversitiesList();

            if(InspectingList.Any())
            {
                InspectingList.RemoveAt(InspectingList.Count - 1);
            }

            if (Inspecting == Inspecting.Groups)
            {
                RefreshUniversitiesList();
                Inspecting = Inspecting.Universities;
            }
            else if(Inspecting == Inspecting.Students)
            {
                RefreshGroupsList(InspectingList.Last());
                Inspecting = Inspecting.Groups;
            }
            else if(Inspecting == Inspecting.StudentMarks)
            {
                RefreshStudentsList(InspectingList.Last());
                Inspecting = Inspecting.Students;
            }
        }

        //Choose Cell
        private void UniversityDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (Inspecting == Inspecting.Universities)
            {
                SelectCellFromUniversityRow(e);
            }
            else if (Inspecting == Inspecting.Groups)
            {
                SelectCellFromGroupRow(e);
            }
            else if (Inspecting == Inspecting.Students)
            {
                SelectCellFromStudentRow(e);
            }
        }

        private void ShowContextMenu(DataGridViewCellMouseEventArgs e)
        {
            universityDataGridView.ClearSelection();
            universityDataGridView.Rows[e.RowIndex].Selected = true;
            var relativeMousePosition = universityDataGridView.PointToClient(Cursor.Position);
            contextMenuStrip1.Show(universityDataGridView, relativeMousePosition);
        }

        private void SelectCellFromUniversityRow(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                ShowContextMenu(e);
                return;
            }

            var table = SelectQuery("SELECT * FROM Universities");
            var universityId = table.Rows[e.RowIndex].Field<int>("UniversityID");
            Inspecting = Inspecting.Groups;
            InspectingList.Add(universityId);
            RefreshGroupsList(universityId);
        }

        private void SelectCellFromGroupRow(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowContextMenu(e);
                return;
            }

            var table = SelectQuery("SELECT * FROM Groups WHERE UniversityID = " + InspectingList.Last());
            var groupId = table.Rows[e.RowIndex].Field<int>("GroupID");
            Inspecting = Inspecting.Students;
            InspectingList.Add(groupId);
            RefreshStudentsList(groupId);
        }

        private void SelectCellFromStudentRow(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowContextMenu(e);
                return;
            }

            DataTable table = SelectQuery("SELECT * FROM Students WHERE GroupID = " + InspectingList.Last());
            int studentId = table.Rows[e.RowIndex].Field<int>("StudentID");
            Inspecting = Inspecting.StudentMarks;
            InspectingList.Add(studentId);
            RefreshRecordsList(studentId);
        }

        //Refresh ViewGrid
        private void RefreshUniversitiesList()
        {
            universityDataGridView.DataSource = null;
            var table = SelectQuery("SELECT UniversityID, UniversityName FROM Universities");
            universityDataGridView.DataSource = table;
            universityDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        private void RefreshGroupsList(int universityId)
        {
            var table = SelectQuery("SELECT g.GroupId, g.GroupName, u.UniversityName " +
                                          "FROM Groups AS g " +
                                          "INNER JOIN Universities as u " +
                                          "ON u.UniversityID = g.UniversityID " +
                                         $"WHERE g.UniversityID = {universityId};");

            universityDataGridView.DataSource = null;
            universityDataGridView.DataSource = table;
            universityDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            RefreshSubjectsList(universityId);
        }

        private void RefreshStudentsList(int groupId)
        {
            var table = SelectQuery("SELECT s.StudentID, s.StudentName, s.StudentSurname, s.StudentAge, g.GroupName " +
                                          "FROM Students AS s " +
                                          "INNER JOIN Groups as g " +
                                          "ON g.GroupID = s.GroupID " +
                                          $"WHERE s.GroupID = {groupId};");

            universityDataGridView.DataSource = null;
            universityDataGridView.DataSource = table;
            universityDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        private void RefreshRecordsList(int studentId)
        {
            var table = SelectQuery("SELECT r.RecordID, su.SubjectName, r.Mark "+
                                            "FROM Records AS r " + 
                                            "INNER JOIN Subjects as su " +
                                            "ON su.SubjectID = r.SubjectID " +
                                            $"WHERE r.StudentID = {studentId}; ");

            universityDataGridView.DataSource = null;
            universityDataGridView.DataSource = table;
            universityDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        private void RefreshSubjectsList(int universityId)
        {
            var subjectList = SelectQuery("SELECT SubjectName FROM Subjects WHERE UniversityID = " + universityId);
            for(int i = 0; i < subjectList.Rows.Count; i++)
            {
                subjectsComboBox.Items.Add(subjectList.Rows[i].Field<string>(0));
            }
        }

        private void EditSubjectsButton_Click(object sender, EventArgs e)
        {
            var form = new SubjectEditForm(InspectingList.First());
            form.Show();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRow = (DataRowView)universityDataGridView.SelectedRows[0].DataBoundItem;

            switch (Inspecting)
            {
                case Inspecting.Universities:
                {
                    var universityId = selectedRow.Row.Field<int>("UniversityID");
                    NonQuery($"DELETE Universities WHERE UniversityID = {universityId}");
                    RefreshUniversitiesList();
                    break;
                }
                case Inspecting.Groups:
                {
                    var groupId = selectedRow.Row.Field<int>("GroupID");
                    NonQuery($"DELETE Groups WHERE GroupID = {groupId}");
                    RefreshGroupsList(InspectingList.Last());
                    break;
                }
                case Inspecting.Students:
                {
                    var studentId = selectedRow.Row.Field<int>("StudentID");
                    NonQuery($"DELETE Students WHERE StudentID = {studentId}");
                    RefreshStudentsList(InspectingList.Last());
                    break;
                }
                case Inspecting.StudentMarks:
                {
                    var recordId = selectedRow.Row.Field<int>("RecordID");
                    NonQuery($"DELETE Records WHERE RecordID = {recordId}");
                    RefreshStudentsList(InspectingList.Last());
                    break;
                }
            }
        }
    }
}