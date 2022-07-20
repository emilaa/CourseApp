using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    public class GroupController
    {
        GroupService groupService = new GroupService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group name : ");

            string groupname = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name : ");

            string teachername = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Blue, "Add room name : ");

            string roomname = Console.ReadLine();

            Group group = new Group
            {
                Name = groupname,
                Teacher = teachername,
                Room = roomname
            };

            var result = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {result.Id}, Name : {result.Name}, Teacher : {result.Teacher}, Room : {result.Room}");
        }
        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

            GroupId: string updateGroupId = Console.ReadLine();
            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add group new name : ");

                string groupNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add group new teacher : ");

                string teacherNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add group new room : ");

                string roomNewName = Console.ReadLine();

                Group group = new Group()
                {
                    Name = groupNewName,
                    Teacher = teacherNewName,
                    Room = roomNewName
                };

                var resultGroup = groupService.Update(groupId, group);

                if (resultGroup == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                    goto GroupId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {resultGroup.Id}, Name : {resultGroup.Name}, Teacher : {resultGroup.Teacher}, Room : {resultGroup.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id : ");
                goto GroupId;
            }
        }
        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
        GroupId: string groupId = Console.ReadLine();

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                groupService.Delete(id);
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type : ");
                goto GroupId;
            }
        }
        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
        GroupId: string groupId = Console.ReadLine();

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                Group group = groupService.GetById(id);

                if (group != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {group.Id}, Name : {group.Name}, Teacher : {group.Teacher}, Room : {group.Room}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found");
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
