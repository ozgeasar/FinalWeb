using FinalWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinalWeb.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Record> Records { get; set; } = new List<Record>();
        public async Task<List<Student>> CreateStudent(Student stu)
        {
            var result = await _httpClient.PostAsJsonAsync<Student>($"api/student", stu);
            var students = await result.Content.ReadFromJsonAsync<List<Student>>();
            return students;
        }

        public async Task GetRecords()
        {
            Records = await _httpClient.GetFromJsonAsync<List<Record>>($"api/student/records");
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"api/student/{id}");
        }

        public async Task<List<Student>> GetStudents()
        {
           return await _httpClient.GetFromJsonAsync<List<Student>>("api/student");
        }
    }
}
