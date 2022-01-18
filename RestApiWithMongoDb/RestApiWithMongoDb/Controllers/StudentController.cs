using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApiWithMongoDb.IRepository;
using RestApiWithMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetStudent();
        }
        public async Task<string> GetStudent()
        {
            var students = await _studentRepository.GetStudents();
            return JsonConvert.SerializeObject(students);
        }
        [HttpPost]
        public async Task<string> Post([FromBody]Student student)
        {
            await _studentRepository.Add(student);
            return "";
        }
    }
}
