using FinalWeb.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Record> records = new List<Record>
        {
            new Record {Name = "credit"},
            new Record {Name = "non credit"}
        };

        List<Student> students = new List<Student>
        {
            new Student {Id=1, FirstName = "Fatma", LastName ="Yılmaz", Status="student", Record = records[0]},
            new Student {Id=2, FirstName = "Ali", LastName ="Arslan", Status="student", Record = records[1]},
        };

        [HttpGet("records")]
        public async Task<IActionResult> GetRecords()
        {
            return Ok(records);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
             return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleStudent(int id)
        {
            var stu = students.FirstOrDefault(h => h.Id == id);
            if (stu == null)
                return NotFound("Student wasn't found.");

            return Ok(stu);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student stu)
        {
            stu.Id = students.Max(h => h.Id + 1);
            students.Add(stu);
            return Ok(students);
        }

    }
}
