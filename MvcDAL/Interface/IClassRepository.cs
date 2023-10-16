using APIDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDAL.Interface
{
    public interface IClassRepository
    {
        public void AddClass(ClassDTOs classDTOs);
        Task<List<ClassDTOs>> GetAllClasses();
        Task<List<ClassDTOs>> GetAllClassesWithoutStudent();
        void DeleteClass(int id);
        Task<ClassDTOs> GetClassById(int id);
        void UpdateClass(ClassDTOs classDTOs);
    }
}
