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
        GroupService groupService = new GroupService();
        
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

        GroupId: string groupid = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupid))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto GroupId;
            }

            int selectedGroupId;
            bool isSelectedId = int.TryParse(groupid, out selectedGroupId);

            var data = groupService.GetById(selectedGroupId);

            if (data != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student name : ");

                StudentName: string studentName = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type : ");
                            goto StudentName;
                        }
                        else if (string.IsNullOrWhiteSpace(studentName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Name can't be space, please try again : ");
                            goto StudentName;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname : ");

                StudentSurname: string studentSurname = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurname.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct surname type : ");
                            goto StudentSurname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentSurname))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Surname can't be space : ");
                            goto StudentSurname;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student age : ");

                Age: string studentAge = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentAge))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Age can't be space, please try again");
                        goto Age;
                    }
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
                            Helper.WriteConsole(ConsoleColor.DarkGreen, "Student created : ");
                            Helper.WriteConsole(ConsoleColor.Green, $"Student group : {result.Group.Name}, Student Id : {result.Id}, Name : {result.Name}, Surname : {result.Surname}, Age : {result.Age}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
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
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct group id type : ");
                    goto GroupId;
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

            if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto StudentId;
            }

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student student = studentService.GetById(id);

                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Student founded : ");
                    Helper.WriteConsole(ConsoleColor.Green, $" Student group : {student.Group.Name}, Student Id : {student.Id}, Name : {student.Name}, Surname : {student.Surname}, Age : {student.Age}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found, please try again : ");
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

            if (string.IsNullOrWhiteSpace(updateStudentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto StudentId;
            }

            int studentId;
            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            var data = studentService.GetById(studentId);

            if (data != null)
            {
                if (isStudentId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new name : ");

                StudentNewName: string studentNewName = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentNewName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type : ");
                            goto StudentNewName;
                        }
                        else if (string.IsNullOrWhiteSpace(studentNewName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Name can't be space, please try again : ");
                            goto StudentNewName;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new surname : ");

                StudentNewSurname: string studentNewSurname = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentNewSurname.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct surname type : ");
                            goto StudentNewSurname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentNewSurname))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Surname can't be space, please try again : ");
                            goto StudentNewSurname;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add student new age : ");

                Age: string studentNewAge = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentNewAge))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Age can't be space, please try again : ");
                        goto Age;
                    }

                    int newAge;
                    bool isNewAge = int.TryParse(studentNewAge, out newAge);

                    if (isNewAge || studentNewAge == "")
                    {

                        bool isAgeEmpty = string.IsNullOrEmpty(studentNewAge);
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
                            Age = newAge
                        };

                        var resultStudent = studentService.Update(studentId, student);

                        if (resultStudent != null)
                        {
                            Helper.WriteConsole(ConsoleColor.DarkGreen, "Student updated : ");
                            Helper.WriteConsole(ConsoleColor.Green, $"Student group : {resultStudent.Group.Name}, Student Id : {resultStudent.Id}, Name : {resultStudent.Name}, Surname : {resultStudent.Surname}, Age : {resultStudent.Age}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Student not found, please try again : ");
                            goto StudentId;
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
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct student id type : ");
                    goto StudentId;
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

            if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto StudentId;
            }

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                var result = studentService.Delete(id);
                
                if (result == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct id : ");
                    goto StudentId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Student deleted ! ");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                goto StudentId;
            }
        }
        public void GetByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student age : ");
        
        StudentAge: string studentAge = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentAge))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Age can't be space, please try again : ");
                goto StudentAge;
            }

            int age;
            bool isStudentAge = int.TryParse(studentAge, out age);

            if (isStudentAge)
            {
                List<Student> resultStudents = studentService.GetByAge(age);
                
                if (resultStudents.Count != 0)
                {
                    foreach (var item in resultStudents)
                    {
                        Helper.WriteConsole(ConsoleColor.DarkGreen, "Students founded : ");
                        Helper.WriteConsole(ConsoleColor.Green, $"Student group : {item.Group.Name}, Student Id : {item.Id}, Name : {item.Name}, Surname : {item.Surname}, Age : {item.Age}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found, please try again : ");
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
            Helper.WriteConsole(ConsoleColor.Blue, "Search with student name or surname : ");

        SearchNameOrSurname: string search = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name or surname can't be space, please try again : ");
                goto SearchNameOrSurname;
            }

            List<Student> resultStudents = studentService.Search(search);

            if (resultStudents.Count != 0)
            {
                foreach (var item in resultStudents)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Result by name or surname : ");
                    Helper.WriteConsole(ConsoleColor.Green, $"Student group : {item.Group.Name}, Student Id : {item.Id}, Name : {item.Name}, Surname : {item.Surname}, Age : {item.Age}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                goto SearchNameOrSurname;
            }
        } 
        public void GetByGroupId()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

        GroupId: string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto GroupId;
            }

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                List<Student> resultStudents = studentService.GetByGroupId(id);
                
                if (resultStudents.Count != 0)
                {
                    foreach (var item in resultStudents)
                    {
                        Helper.WriteConsole(ConsoleColor.DarkGreen, "Students founded : ");
                        Helper.WriteConsole(ConsoleColor.Green, $"Student group : {item.Group.Name}, Student Id : {item.Id}, Name : {item.Name}, Surname : {item.Surname}, Age : {item.Age}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                    goto GroupId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                goto GroupId;
            }
        }
    }
}
