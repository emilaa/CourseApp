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
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");

        GroupId: string groupid = Console.ReadLine();
            int selectedGroupId;
            bool isSelectedId = int.TryParse(groupid, out selectedGroupId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add student name : ");

                string studentName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add student surname : ");

                string studentSurname = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add student age : ");

                Age: string studentAge = Console.ReadLine();
                int age;
                bool isAge = int.TryParse(studentAge, out age);

                if (isAge)
                {
                    Student student = new Student
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
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct group id : ");
                    goto GroupId;
                }
                
                
            }
            
        }
    }
}
