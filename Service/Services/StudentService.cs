using Domain.Models;
using Repository.Repositories;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            _count++;
            return student;
        }

        public object Create(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
