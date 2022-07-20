using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public enum Menues
    {
        CreateGroup = 1,
        UpdateGroup = 2,
        DeleteGroup = 3,
        GetGroupById = 4,
        GetAllGroupsByTeacher = 5,
        GetAllGroupsByRoom = 6,
        GetAllGroups = 7,
        CreateStudent = 8,
        UpdateStudent = 9,
        GetStudentById = 10,
        DeleteStudent = 11,
        GetStudentsByAge = 12,
        GetAllStudentsByGroupId = 13,
        SearchForGroupsByName = 14,
        SearchForStudentsByNameOrSurname = 15
    }
}
