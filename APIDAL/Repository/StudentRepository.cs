using APIDAL.AppContext;
using APIDAL.Interface;
using APIDomainEntities;
using APIDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APIDAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;
        public StudentRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;

        }
        public void AddStudent(StudentDTOs studentDTOs)
        {
            try
            {

                Student student = ToEntity(studentDTOs);
                dbContext.Add(student);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<StudentDTOs> GetAllStudents()
        {
            try
            {

                List<Student> students = dbContext.Students.Include(x=>x.Class).ToList();
                List<StudentDTOs> studentDTOs = ToDtos(students);
                return studentDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public void DeleteStudent(int id)
        {
            try
            {
                var student =  dbContext.Students.Where(x=> x.Id == id).FirstOrDefault();
                if (student != null)
                {
                    dbContext.Students.Remove(student);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateStudent(StudentDTOs studentDTOs)
        {
            try
            {

                var student = dbContext.Students.Where(x => x.Id == studentDTOs.Id).FirstOrDefault();
                if (student != null)
                {
                    UpdateStudent(student, studentDTOs);
                    dbContext.SaveChanges();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public StudentDTOs GetStudentById(int id)
        {
            try
            {
                var student = dbContext.Students.Where(x => x.Id == id).Include(x=>x.Class).FirstOrDefault();
                if(student != null)
                {
                    var studentDto = ToDto(student);
                    return studentDto;
                }
                StudentDTOs studentDtos = new StudentDTOs();
                return studentDtos;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private Student ToEntity(StudentDTOs studentDTOs)
        {
            Student student = new Student()
            {
                Id = studentDTOs.Id,
                Name = studentDTOs.Name,
                FatherName = studentDTOs.FatherName,
                Email = studentDTOs.Email,
                Phone = studentDTOs.Phone,
                ClassId = studentDTOs.ClassId,
            };
            return student;
        }
        private void UpdateStudent(Student student , StudentDTOs studentDTOs)
        {
            student.Id = studentDTOs.Id;
            student.Name = studentDTOs.Name;
            student.FatherName = studentDTOs.FatherName;
            student.Email = studentDTOs.Email;
            student.Phone = studentDTOs.Phone;
            student.ClassId = studentDTOs.ClassId;
        }
        private List<StudentDTOs> ToDtos(List<Student> students)
        {
            List<StudentDTOs> studentDTOs = new List<StudentDTOs>();
            foreach (var student in students)
            {
                StudentDTOs studentDTO = new StudentDTOs()
                {
                    Id = student.Id,
                    Name = student.Name,
                    FatherName = student.FatherName,
                    Email = student.Email,
                    Phone = student.Phone,
                    ClassName = student.Class.ClassName
                    
                };
                studentDTOs.Add(studentDTO);
            }
            return studentDTOs;
        }
        private StudentDTOs ToDto(Student student)
        {
            StudentDTOs studentDTO = new StudentDTOs()
            {
                Id = student.Id,
                Name = student.Name,
                FatherName = student.FatherName,
                Email = student.Email,
                Phone = student.Phone,
                ClassName = student.Class.ClassName,
                ClassId = student.Class.Id
            };
            return studentDTO;
        }
    }
}
