using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = _count;

            _groupRepository.Create(group);
            _count++;

            return group;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);
            _groupRepository.Delete(group);
        }

        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        }

        public Group Update(int id, Group library)
        {
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            library.Id = dbGroup.Id;
            _groupRepository.Update(library);
            return dbGroup;
        }
    }
}
