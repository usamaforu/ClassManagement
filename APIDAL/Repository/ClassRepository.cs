using APIDAL.AppContext;
using APIDAL.Interface;
using APIDomainEntities;
using APIDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext dbContext;
        public ClassRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void AddClasses(ClassDTOs dtoObject)
        {
            try
            {
                Class classs = ToEntity(dtoObject);
                dbContext.Add(classs);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ClassDTOs> GetAllClasses()
        {
            try
            {
                var classes = dbContext.Classes.Include(x => x.Students).ToList();
                List<ClassDTOs> classDto = ToDtos(classes);
                return classDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
      

        public void DeleteClass(int id)
        {
            try
            {
                var classs = dbContext.Classes.Where(x => x.Id == id).FirstOrDefault();
                if (classs != null)
                {
                    dbContext.Classes.Remove(classs);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateClass(ClassDTOs classDTOs)
        {
            try
            {
                var classs = dbContext.Classes.Where(x => x.Id == classDTOs.Id).FirstOrDefault();
                if(classs != null)
                {
                    UpdateClass(classs,classDTOs);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ClassDTOs GetClassById(int id)
        {
            var classs = dbContext.Classes.Where(x=>x.Id == id).FirstOrDefault();   
            if(classs != null)
            {
                var classDTo = ToDTo(classs);
                return classDTo;
            }
            ClassDTOs classDto = new ClassDTOs();
            return classDto;
        }

        public List<ClassDTOs> GetClassesWithoutStudent()
        {
            try
            {
                var classes = dbContext.Classes.ToList();
                List<ClassDTOs> classDTOs = ToDto(classes); 
                return classDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private Class ToEntity(ClassDTOs dtoObject)
        {
            Class classs = new Class()
            {
                Id = dtoObject.Id,
                ClassName = dtoObject.ClassName
            };
            return classs;
        }
        private List<ClassDTOs> ToDtos(List<Class> classes)
        {
            try
            {
                List<ClassDTOs> classesDTOs = new List<ClassDTOs>();
                foreach (var classs in classes)
                {
                    ClassDTOs classDTOs = new ClassDTOs()
                    {
                        Id = classs.Id,
                        ClassName = classs.ClassName,
                        Students= ToStudentDTo(classs.Students)

                    };
                    classesDTOs.Add(classDTOs);
                }
                return classesDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<ClassDTOs> ToDto(List<Class> classes)
        {
            try
            {
                List<ClassDTOs> classesDTOs = new List<ClassDTOs>();
                foreach (var classs in classes)
                {
                    ClassDTOs classDTOs = new ClassDTOs()
                    {
                        Id = classs.Id,
                        ClassName = classs.ClassName

                    };
                    classesDTOs.Add(classDTOs);
                }
                return classesDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<StudentDTOs> ToStudentDTo(List<Student> students )
        {
            List<StudentDTOs> studentDTOs = new List<StudentDTOs>();
            foreach(Student student in students)
            {
                StudentDTOs studetnDto = new StudentDTOs()
                {
                    Id = student.Id,
                    FatherName = student.FatherName,
                    Name = student.Name,
                    Email = student.Email,
                    Phone = student.Phone,

                };
                studentDTOs.Add(studetnDto);
            }
            return studentDTOs;
        }
        private void UpdateClass(Class classs ,ClassDTOs classDTOs)
        {
            classs.Id = classDTOs.Id;
            classs.ClassName = classDTOs.ClassName;
        }
        private ClassDTOs ToDTo(Class classs)
        {
            ClassDTOs classDTo = new ClassDTOs()
            {
                Id = classs.Id,
                ClassName = classs.ClassName
            };
            return classDTo;
        }
    }
}
