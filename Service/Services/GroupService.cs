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

        public Group Delete(int id)
        {
            Group group = GetById(id);
            if (group == null) return null;
            _groupRepository.Delete(group);
            return group;
        }

        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
            _groupRepository.Update(group);
            return dbGroup;
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }
        public List<Group> Search(string search)
        {
            return _groupRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.Trim().ToLower()));
        }
    }
}
 