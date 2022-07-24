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

            GroupName: string groupname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                goto GroupName;
            }

            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name : ");

        TeacherName: string teachername = Console.ReadLine();

            for (int i = 0; i <= 9; i++)
            {
                if (teachername.Contains(i.ToString()))
                {
                    Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type : ");
                    goto TeacherName;
                }
                else if (string.IsNullOrWhiteSpace(teachername))
                {
                    Helper.WriteConsole(ConsoleColor.Red, $"Name can't be space, please try again : ");
                    goto TeacherName;
                }
            }

            Helper.WriteConsole(ConsoleColor.Blue, "Add room name : ");

            RoomName: string roomname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(roomname))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                goto RoomName;
            }

            Group group = new Group
            {
                Name = groupname,
                Teacher = teachername,
                Room = roomname
            };

            var result = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.DarkGreen, "Group created : ");
            Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {result.Id}, Name : {result.Name}, Teacher : {result.Teacher}, Room : {result.Room}");
        }
        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");

            GroupId: string updateGroupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(updateGroupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id can't be space, please try again : ");
                goto GroupId;
            }

            int groupId;
            bool isGroupId = int.TryParse(updateGroupId, out groupId);
            
            var data = groupService.GetById(groupId);

            if (data != null )
            {
                if (isGroupId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add group new name : ");

                    GroupName: string groupNewName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(groupNewName))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                        goto GroupName;
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add group new teacher : ");

                TeacherName: string teacherNewName = Console.ReadLine();

                    for (int i = 0; i <= 9; i++)
                    {
                        if (teacherNewName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type : ");
                            goto TeacherName;
                        }
                        else if (string.IsNullOrWhiteSpace(teacherNewName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, $"Name can't be space, please try again : ");
                            goto TeacherName;
                        }
                    }

                    Helper.WriteConsole(ConsoleColor.Blue, "Add group new room : ");

                    RoomName: string roomNewName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(roomNewName))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                        goto RoomName;
                    }

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
                        Helper.WriteConsole(ConsoleColor.DarkGreen, "Group updated : ");
                        Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {resultGroup.Id}, Name : {resultGroup.Name}, Teacher : {resultGroup.Teacher}, Room : {resultGroup.Room}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                    goto GroupId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                goto GroupId;
            }
        }
        public void Delete()
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
                var result = groupService.Delete(id);
                if (result == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct id : ");
                    goto GroupId;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Group deleted ! ");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                goto GroupId;
            }
        }
        public void GetById()
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
                Group group = groupService.GetById(id);

                if (group != null)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Group founded : ");
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Name : {group.Name}, Teacher : {group.Teacher}, Room : {group.Room}");
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
        public void GetAll()
        {
            List<Group> groups = groupService.GetAll();

            foreach (var item in groups)
            {
                Helper.WriteConsole(ConsoleColor.DarkGreen, "All groups founded : ");
                Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Name : {item.Name}, Teacher : {item.Teacher}, Room : {item.Room}");
            }
        }
        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Search with group name : ");

        SearchName: string search = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                goto SearchName;
            }

            List<Group> resultGroups = groupService.Search(search);

            if (resultGroups.Count != 0)
            {
                foreach (var item in resultGroups)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Result by name : ");
                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {item.Id}, Name : {item.Name}, Teacher : {item.Teacher}, Room : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again : ");
                goto SearchName;
            }
        }
        public void GetByTeacher()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name : ");
        
        TeacherName: string teacherName = Console.ReadLine();

            for (int i = 0; i <= 9; i++)
            {
                if (teacherName.Contains(i.ToString()))
                {
                    Helper.WriteConsole(ConsoleColor.Red, $"Add correct name type : ");
                    goto TeacherName;
                }
                else if (string.IsNullOrWhiteSpace(teacherName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, $"Name can't be space, please try again : ");
                    goto TeacherName;
                }
            }

            List<Group> resultTeachers = groupService.GetByTeacher(teacherName);

            if (resultTeachers.Count != 0)
            {
                foreach (var item in resultTeachers)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Groups founded : ");
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Name : {item.Name}, Teacher : {item.Teacher}, Room : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher not found, please try again : ");
                goto TeacherName;
            }
        }
        public void GetByRoom()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add room name : ");

            RoomName: string roomName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(roomName))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Name can't be space, please try again : ");
                goto RoomName;
            }

            List<Group> resultRooms = groupService.GetByRoom(roomName);

            if (resultRooms.Count != 0)
            {
                foreach (var item in resultRooms)
                {
                    Helper.WriteConsole(ConsoleColor.DarkGreen, "Groups founded : ");
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Name : {item.Name}, Teacher : {item.Teacher}, Room : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Room not found ! ");
                goto RoomName;
            }
        }  
    }
}
