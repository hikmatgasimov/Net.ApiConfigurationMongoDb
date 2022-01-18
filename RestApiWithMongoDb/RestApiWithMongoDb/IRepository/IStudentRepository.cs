using RestApiWithMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithMongoDb.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task Add(Student students);
    }
}
