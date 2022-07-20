﻿using CourseApp.Controllers;
using Service.Helpers;
using Service.Services;
using System;

namespace CourseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupService libraryService = new GroupService();

            GroupController groupController = new GroupController();

            StudentController studentController = new StudentController();

            GetMenues();

            while (true)
            {
                string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menues.CreateGroup:
                            groupController.Create();
                            break;

                        case (int)Menues.UpdateGroup:
                            groupController.Update();
                            break;

                        case (int)Menues.DeleteGroup:
                            groupController.Delete();
                            break;

                        case (int)Menues.GetGroupById:
                            groupController.GetById();
                            break;

                        case (int)Menues.CreateStudent:
                            studentController.Create();
                            break;

                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number");
                            break;
                    }
                }
            }
        }

        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Select one option : ");
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create group, 2 - Update group, 3 - Delete group, 4 - Get group by id," +
                "5 - Get all groups by teacher, 6 - Get all groups by room, 7 - Get all groups, 8 - Create student, 9 - Update student" +
                "10 - Get student  by id, 11 - Delete student, 12 - Get students by age, 13 - Get all students by group id" +
                "14 - Search for groups by name, 15 - Search for students by name or surname");
        }
    }
}