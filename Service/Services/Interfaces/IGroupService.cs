﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        Group Delete(int id);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> Search(string search);
        List<Group> GetByTeacher(string teacher);
        List<Group> GetByRoom(string room);
    }
}
