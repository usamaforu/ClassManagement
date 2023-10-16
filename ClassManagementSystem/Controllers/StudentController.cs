using APIDAL.Interface;
using APIDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent(StudentDTOs studentDTOs)
        {
            studentRepository.AddStudent(studentDTOs);
            return Ok("Student Add Successfull");
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
           var students = studentRepository.GetAllStudents();
            return Ok(students);
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            studentRepository.DeleteStudent(id);
            return Ok("Student Deleted Successful");
        }
        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(StudentDTOs studentDTOs)
        {
            studentRepository.UpdateStudent(studentDTOs);
            return Ok("Student Updated successfull");
        }
        [HttpGet("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            var student = studentRepository.GetStudentById(id);
            return Ok(student);

        }
    }
}
