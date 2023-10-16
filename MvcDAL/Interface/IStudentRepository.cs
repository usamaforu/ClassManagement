using APIDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDAL.Interface
{
    public interface IStudentRepository
    {
        public void AddStudent(StudentDTOs studentDTOs);
        Task<List<StudentDTOs>> GetAllStudents();
        void Delete(int id);
        Task<StudentDTOs> GetStudentById(int id);
        void UpdateStudent(StudentDTOs studentDTOs);
    }
}
