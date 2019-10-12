using System;

namespace University
{
    class Program
    {
        static IUniversity university = new University("NURE", new TableFormatter());
        
        static string Commands()
        {
            string result = string.Empty;
            result += "Commands: \n";
            result += "1 - add group\n";
            result += "2 - add student\n";
            result += "3 - add teacher\n";
            result += "4 - add subject\n";
            result += "5 - set teacher to subject\n";
            result += "6 - add subject to record book\n";
            result += "7 - add mark to record book\n";
            result += "8 - view all groups\n";
            result += "9 - view all students\n";
            result += "10 - view all teachers\n";
            result += "11 - view all subjects";
            return result;
        }

        static void DoCommand()
        {
            Console.WriteLine($"Welcome to {(university as University).UniversityName} database. Here are some usefull commands: ");
            Console.WriteLine(Commands());
        Command:
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    AddGroup();
                    break;
                case 2:
                    AddStudent();
                    break;
                case 3:
                    AddTeacher();
                    break;
                case 4:
                    AddSubject();
                    break;
                case 5: SetTeacherToSubject();
                    break;
                case 6:
                    AddSubjectToRecordBook();
                    break;
                case 7:
                    AddMarkToRecordBook();
                    break;
                case 8:
                    Console.WriteLine(university.GetFormattedGroups());
                    break;
                case 9:
                    Console.WriteLine(university.GetFormattedStudents());
                    break;
                case 10:
                    Console.WriteLine(university.GetFormattedTeachers());
                    break;
                case 11:
                    Console.WriteLine(university.GetFormattedSubjects());
                    break;
                default:
                    Console.WriteLine("Error: wrong input");
                    break;
            }
            goto Command;
        }

        static void AddGroup()
        {
            Console.WriteLine("Enter group name:");
            bool output = university.AddGroup(Console.ReadLine());
            if(output)
            {
                Console.WriteLine("Group is created succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't create group");
        }

        static void AddStudent()
        {
            Console.WriteLine(university.GetFormattedGroups());
            Console.WriteLine("Enter group number you want student to be in: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter student age: ");
            int age = int.Parse(Console.ReadLine());
            if(university.AddStudentToGroup(group, name, surname, age))
            {
                Console.WriteLine("Student added succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't add student");
        }

        static void AddTeacher()
        {
            Console.WriteLine("Enter teachers name, surname, age");
            if (university.AddTeacher(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Teacher is created succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't create teacher");
        }

        static void AddSubject()
        {
            Console.WriteLine("Enter subject name");
            if(university.AddSubject(Console.ReadLine()))
            {
                Console.WriteLine("Subject is created succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't create subject");
        }

        static void SetTeacherToSubject()
        {
            Console.WriteLine("Enter subject name");
            Console.WriteLine(university.GetFormattedSubjects());
            int subject = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter teacher name");
            Console.WriteLine(university.GetFormattedTeachers());
            int teacher = int.Parse(Console.ReadLine());
            if (university.SetTeacherToSubject(teacher, subject))
            {
                Console.WriteLine("Teacher is set to subject succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't set teacher to subject");
        }

        static void AddSubjectToRecordBook()
        {
            Console.WriteLine(university.GetFormattedGroups());
            Console.WriteLine("Enter group number of student: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine(university.GetFormattedStudents());
            Console.WriteLine("Enter student number: ");
            int student = int.Parse(Console.ReadLine());
            Console.WriteLine(university.GetFormattedSubjects());
            Console.WriteLine("Enter subject number: ");
            int subject = int.Parse(Console.ReadLine());
            if(university.AddSubjectToRecordBook(group, student, subject))
            {
                Console.WriteLine("Subject added succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't add subject");
        }

        static void AddMarkToRecordBook()
        {
            Console.WriteLine(university.GetFormattedGroups());
            Console.WriteLine("Enter group number of student: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine(university.GetFormattedStudents());
            Console.WriteLine("Enter student number: ");
            int student = int.Parse(Console.ReadLine());
            Console.WriteLine(university.GetFormattedRecordBook(group, student));
            Console.WriteLine("Enter subject number: ");
            int subject = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter mark: ");
            int mark = int.Parse(Console.ReadLine());
            if (university.AddMarkToRecordBook(group, student, mark, subject))
            {
                Console.WriteLine("Mark added succesfully!");
                return;
            }
            Console.WriteLine("Error: couldn't add mark");
        }
       
        static void Main(string[] args)
        {
            Generator gen = new Generator(university);
            gen.GenerateGroups(8);
            gen.GenerateStudents(80);
            gen.GenerateSubjectsAndTeachers(5);
            gen.GenerateMarksToStudents();
            DoCommand();
        }
    }
}
