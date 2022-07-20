using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Inrerfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class GroupRepository : IRepository <Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");

                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Group Get(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public void Update(Group data)
        {
            Group library = Get(m => m.Id == data.Id);

            if (!string.IsNullOrEmpty(data.Name))
                library.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Teacher))
                library.Teacher = data.Teacher;

            if (!string.IsNullOrEmpty(data.Room))
                library.Room = data.Room;
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }
    }
}
