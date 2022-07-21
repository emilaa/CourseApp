using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

        GroupId: string groupid = Console.ReadLine();
            int selectedGroupId;
            bool isSelectedId = int.TryParse(groupid, out selectedGroupId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add student name : ");

                StudentName: string studentName = Console.ReadLine();

                foreach (var item in studentName)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type");
                            goto StudentName;
                        }
                    }
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add student surname : ");

                StudentSurname: string studentSurname = Console.ReadLine();

                foreach (var item in studentSurname)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct surname type");
                            goto StudentSurname;
                        }
                    }
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add student age : ");

                Age: string studentAge = Console.ReadLine();
                int age;
                bool isAge = int.TryParse(studentAge, out age);

                if (isAge)
                {
                    Student student = new Student()
                    {
                        Name = studentName,
                        Surname = studentSurname,
                        Age = age
                    };

                    var result = studentService.Create(selectedGroupId, student);

                    if (result != null)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {result.Id}, Name : {result.Name}, Surname : {result.Surname}, Age : {result.Age}, Student group : {result.Group.Name}");
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Group not found, please add correct group id : ");
                        goto GroupId;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct age type : ");
                    goto Age;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id : ");
                goto GroupId;
            }
        }
        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
        StudentId: string studentId = Console.ReadLine();

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student student = studentService.GetById(id);

                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {student.Id}, Name : {student.Name}, Surname : {student.Surname}, Age : {student.Age}, Student group : {student.Group.Name}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found");
                    goto StudentId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                goto StudentId;
            }
        }
        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");

        StudentId: string updateStudentId = Console.ReadLine();
            int studentId;
            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            if (isStudentId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add student new name : ");

                StudentNewName: string studentNewName = Console.ReadLine();

                foreach (var item in studentNewName)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type");
                            goto StudentNewName;
                        }
                    }
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add student new surname : ");

            StudentNewSurname: string studentNewSurname = Console.ReadLine();

                foreach (var item in studentNewSurname)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        if (item.ToString() == i.ToString())
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct surname type");
                            goto StudentNewSurname;
                        }
                    }
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add student new age : ");

                Age: string studentNewAge = Console.ReadLine();
                int newAge;
                bool isNewAge = int.TryParse(studentNewAge, out newAge);

                if (isNewAge || studentNewAge == "")
                {

                    bool isSeatCountEmpty = string.IsNullOrEmpty(studentNewAge);
                    int? age = null;

                    if (isNewAge)
                    {
                        age = null;
                    }
                    else
                    {
                        age = newAge;
                    }

                    Student student = new Student()
                    {
                        Name = studentNewName,
                        Surname = studentNewSurname,
                        Age = age
                    };

                    var resultStudent = studentService.Update(studentId, student);

                    if (resultStudent == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student not found, please try again : ");
                        goto StudentId;
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {resultStudent.Id}, Name : {resultStudent.Name}, Surname : {resultStudent.Surname}, Age : {resultStudent.Age},Student group : {resultStudent.Group.Name}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct age type : ");
                    goto Age;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct student id : ");
                goto StudentId;
            }
        }
        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
        StudentId: string studentId = Console.ReadLine();

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                var result = studentService.Delete(id);
                if (result == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct id : ");
                    goto StudentId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Green, "Student deleted");
                    goto StudentId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type : ");
                goto StudentId;
            }
        }
        public void GetByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student age : ");
        StudentAge: string studentAge = Console.ReadLine();

            int age;
            bool isStudentAge = int.TryParse(studentAge, out age);

            if (isStudentAge)
            {
                Student student = studentService.GetByAge(age);

                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {student.Id}, Name : {student.Name}, Surname : {student.Surname}, Age : {student.Age}, Student group : {student.Group.Name}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found");
                    goto StudentAge;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct age type : ");
                goto StudentAge;
            }
        }
        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group search name or surname : ");

        SearchNameOrSurname: string search = Console.ReadLine();

            List<Student> resultStudents = studentService.Search(search);

            if (resultStudents.Count != 0)
            {
                foreach (var item in resultStudents)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student Id : {item.Id}, Name : {item.Name}, Surname : {item.Surname}, Age : {item.Age}, Student group : {item.Group.Name}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found");
                goto SearchNameOrSurname;
            }
        }
    }
}
