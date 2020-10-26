using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L04
{
    public interface IStudentsRepository
    {
        Task<List<StudentEntity>> GetAllStudents();

        Task<StudentEntity> GetStudent(string id);

        Task InsertNewStudent(StudentEntity student);

        Task EditStudent(StudentEntity student);

        Task DeleteStudent(string id);
    }
}
