using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Deployment.Application;
using UniversityApp.Entities;
using UniversityApp.Forms.Service;
using UniversityApp.Forms.Service.Abstractions;
using UniversityApp.Forms.Service.Repositories;
using UniversityApp.Forms.Validation;

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
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly List<int> _inspectingList;
        private Inspecting _inspecting;

        public Form1()
        {
            InitializeComponent();
            _inspecting = Inspecting.Universities;
            _inspectingList = new List<int>();
            _dataAccessProvider = new DataAccessProvider();
            RefreshUniversitiesList();
        }

        ////Adding
        //Adding Button Clicks
        private void AddUniversityButton_Click(object sender, EventArgs e)
        {
            var universityRepository = new UniversityRepository();
            var universityValidation = new UniversityValidation();

            var university = new University(addUniversityNameTextBox.Text);

            if (!universityValidation.IsValidUniversity(university) && _inspecting != Inspecting.Universities)
            {
                return;
            }

            universityRepository.Create(university);

            RefreshUniversitiesList();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            var groupRepository = new GroupRepository();
            var groupValidation = new GroupValidation();

            var groupName = addGroupNameTextBox.Text;
            var group = new Group(groupName);

            if (groupValidation.IsValidGroup(group))
            {
                return;
            }

            groupRepository.Create(group);

            RefreshGroupsList(_inspectingList.Last());
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            var studentRepository = new StudentRepository();
            var studentValidation = new StudentValidation();

            var name = addStudentNameTextBox.Text;
            var surname = addStudentSurnameTextBox.Text;
            var age = (int)addStudentAgeNumericUpDown.Value;
            var student = new Student(name, surname, age);

            if (!studentValidation.IsValidStudent(student))
            {
                return;
            }

            studentRepository.Create(student);

            RefreshStudentsList(_inspectingList.Last());
        }

        private void AddRecordButton_Click(object sender, EventArgs e)
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT * FROM Subjects WHERE UniversityID = " + _inspectingList.First());
            DataRow row = table.Select($"SubjectName = \'{subjectsComboBox.Text}\' ").Single();
            var mark = subjectsNumeric.Value;
            var subjectId = row.Field<int>("SubjectID");

            _dataAccessProvider.ExecuteNonQuery("INSERT INTO Records (Mark, StudentID, SubjectID) " +
                        $"values ('{mark}', '{_inspectingList.Last()}', {subjectId})");

            RefreshRecordsList(_inspectingList.Last());
        }

        ////

        //Return Back
        private void BackButton_Click(object sender, EventArgs e)
        {
            RefreshUniversitiesList();

            if(_inspectingList.Any())
            {
                _inspectingList.RemoveAt(_inspectingList.Count - 1);
            }

            if (_inspecting == Inspecting.Groups)
            {
                RefreshUniversitiesList();
                _inspecting = Inspecting.Universities;
            }
            else if(_inspecting == Inspecting.Students)
            {
                RefreshGroupsList(_inspectingList.Last());
                _inspecting = Inspecting.Groups;
            }
            else if(_inspecting == Inspecting.StudentMarks)
            {
                RefreshStudentsList(_inspectingList.Last());
                _inspecting = Inspecting.Students;
            }
        }

        //Choose Cell
        private void UniversityDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (_inspecting == Inspecting.Universities)
            {
                SelectCellFromUniversityRow(e);
            }
            else if (_inspecting == Inspecting.Groups)
            {
                SelectCellFromGroupRow(e);
            }
            else if (_inspecting == Inspecting.Students)
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

            var universityRepository = new UniversityRepository();;

            var table = universityRepository.FindAll();
            var universityId = table.Rows[e.RowIndex].Field<int>("UniversityID");
            _inspecting = Inspecting.Groups;
            _inspectingList.Add(universityId);
            RefreshGroupsList(universityId);
        }

        private void SelectCellFromGroupRow(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowContextMenu(e);
                return;
            }

            var groupRepository = new GroupRepository();

            var table = groupRepository.FindAllFrom(_inspectingList.Last());
            var groupId = table.Rows[e.RowIndex].Field<int>("GroupID");
            _inspecting = Inspecting.Students;
            _inspectingList.Add(groupId);
            RefreshStudentsList(groupId);
        }

        private void SelectCellFromStudentRow(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ShowContextMenu(e);
                return;
            }

            var studentRepository = new StudentRepository();

            var table = studentRepository.FindAllFrom(_inspectingList.Last());
            var studentId = table.Rows[e.RowIndex].Field<int>("StudentID");
            _inspecting = Inspecting.StudentMarks;
            _inspectingList.Add(studentId);
            RefreshRecordsList(studentId);
        }

        //Refresh ViewGrid
        private void RefreshUniversitiesList()
        {
            universityDataGridView.DataSource = null;

            var table = _dataAccessProvider.ExecuteQuery("SELECT UniversityID, UniversityName FROM Universities");
            universityDataGridView.DataSource = table;
            universityDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        private void RefreshGroupsList(int universityId)
        {
            var table = _dataAccessProvider.ExecuteQuery("SELECT g.GroupId, g.GroupName, u.UniversityName " +
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
            var table = _dataAccessProvider.ExecuteQuery("SELECT s.StudentID, s.StudentName, s.StudentSurname, s.StudentAge, g.GroupName " +
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
            var table = _dataAccessProvider.ExecuteQuery("SELECT r.RecordID, su.SubjectName, r.Mark " +
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
            var subjectList = _dataAccessProvider.ExecuteQuery("SELECT SubjectName FROM Subjects WHERE UniversityID = " + universityId);
            for(int i = 0; i < subjectList.Rows.Count; i++)
            {
                subjectsComboBox.Items.Add(subjectList.Rows[i].Field<string>(0));
            }
        }
        
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRow = (DataRowView)universityDataGridView.SelectedRows[0].DataBoundItem;

            switch (_inspecting)
            {
                case Inspecting.Universities:
                {
                    var universityId = selectedRow.Row.Field<int>("UniversityID");
                    _dataAccessProvider.ExecuteNonQuery($"DELETE Universities WHERE UniversityID = {universityId}");
                    RefreshUniversitiesList();
                    break;
                }
                case Inspecting.Groups:
                {
                    var groupId = selectedRow.Row.Field<int>("GroupID");
                    _dataAccessProvider.ExecuteNonQuery($"DELETE Groups WHERE GroupID = {groupId}");
                    RefreshGroupsList(_inspectingList.Last());
                    break;
                }
                case Inspecting.Students:
                {
                    var studentId = selectedRow.Row.Field<int>("StudentID");
                    _dataAccessProvider.ExecuteNonQuery($"DELETE Students WHERE StudentID = {studentId}");
                    RefreshStudentsList(_inspectingList.Last());
                    break;
                }
                case Inspecting.StudentMarks:
                {
                    var recordId = selectedRow.Row.Field<int>("RecordID");
                    _dataAccessProvider.ExecuteNonQuery($"DELETE Records WHERE RecordID = {recordId}");
                    RefreshStudentsList(_inspectingList.Last());
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}