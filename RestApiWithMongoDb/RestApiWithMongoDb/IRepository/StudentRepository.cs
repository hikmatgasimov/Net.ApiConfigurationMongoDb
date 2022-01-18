using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestApiWithMongoDb.Dbmodels;
using RestApiWithMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithMongoDb.IRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ObjectContext _context = null;
        public StudentRepository(IOptions<Setting> settings)
        {
            _context = new ObjectContext(settings);
        }
        public async Task Add(Student students)
        {
            await _context.Students.InsertOneAsync(students);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.Find(x => true).ToListAsync();
        }
    }
}
