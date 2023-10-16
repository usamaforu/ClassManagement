using APIDomainEntities;
using APIDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Interface
{
    public interface IClassRepository
    {
        public List<ClassDTOs> GetAllClasses();
        public List<ClassDTOs> GetClassesWithoutStudent();
        public void AddClasses(ClassDTOs  dtoObject);
        public void DeleteClass(int id);
        public void UpdateClass(ClassDTOs classDTOs);
        public ClassDTOs GetClassById(int id);
    }
}
