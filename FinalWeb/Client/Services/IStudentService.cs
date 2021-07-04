using FinalWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWeb.Client.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);

        Task<List<Student>> CreateStudent(Student stu);
    }
}
