using FinalWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWeb.Client.Services
{
    public interface IStudentService
    {
        event Action OnChange;
        List<Record> Records { get; set; }
        List<Student> Students { get; set; }
        Task<List<Student>> GetStudents();
        Task GetRecords();
        Task<Student> GetStudent(int id);

        Task<List<Student>> CreateStudent(Student stu);
    }
}
