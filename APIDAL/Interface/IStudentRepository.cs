using APIDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Interface
{
    public interface IStudentRepository
    {
       public void AddStudent(StudentDTOs studentDTOs); 
        public List<StudentDTOs> GetAllStudents();
        public void DeleteStudent(int id);
        public void UpdateStudent(StudentDTOs studentDTOs);
        public StudentDTOs GetStudentById(int id);
    }
}
