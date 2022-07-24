using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);
        Student GetById(int id);
        Student Update(int id, Student student);
        Student Delete(int id);
        List<Student> GetByAge(int age);
        List<Student> Search(string search);
        List<Student> GetAll();
        List<Student> GetByGroupId(int id);
    }
}
