using APIDTOs;
using Microsoft.AspNetCore.Mvc;
using MvcDAL.Interface;

namespace FrontEnd_MVC_.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IClassRepository classRepository;
        public StudentController(IStudentRepository _studentRepository, IClassRepository classRepository)
        {
            studentRepository = _studentRepository;
            this.classRepository = classRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public async Task<ActionResult> AddStudent()
        {
            ViewBag.list =await classRepository.GetAllClassesWithoutStudent();
            return View();
        }
        [HttpPost()]
        public ActionResult AddStudent(StudentDTOs studentDTOs )
        {
            studentRepository.AddStudent(studentDTOs);
            return RedirectToAction("GetAllStudents");
        }
        [HttpGet()]
        public async Task<ActionResult> GetAllStudents()
        {
           var students = await studentRepository.GetAllStudents();
            return View(students);

        }
        public ActionResult Delete(int id)
        {
            studentRepository.Delete(id);
            return RedirectToAction("GetAllStudents");
        }
        public  async Task<ActionResult> Edit(int id)
        {
            ViewBag.list = await classRepository.GetAllClassesWithoutStudent();
            StudentDTOs student = await studentRepository.GetStudentById(id);
            return View(student);   
        }
        [HttpPost]
        public async Task<ActionResult> Edit(StudentDTOs studentDTOs)
        {
            studentRepository.UpdateStudent(studentDTOs);
            return RedirectToAction("GetAllStudents");
        }
    }
}
