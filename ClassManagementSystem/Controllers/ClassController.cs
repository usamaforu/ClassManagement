using APIDAL.Interface;
using APIDomainEntities;
using APIDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository classRepository;
        public ClassController(IClassRepository _classRepository)
        {
            classRepository = _classRepository;
        }
        [HttpPost("AddClass")]
        public IActionResult AddClass(ClassDTOs dtoObject)
        {
            classRepository.AddClasses(dtoObject);
            return Ok("Class Added Successfull");
        }
        [HttpGet("GetAllClasses")]
        public IActionResult GetAllclasses()
        {
            var classes = classRepository.GetAllClasses();
            return Ok(classes);
        }
        [HttpDelete("DeleteClass")]
        public IActionResult DeleteClass(int id)
        {
            classRepository.DeleteClass(id);
            return Ok("Class Deleted");
        }
        [HttpPut("UpdateClass")]
        public IActionResult UpdateClass(ClassDTOs classDTOs) 
        {
            classRepository.UpdateClass(classDTOs);
            return Ok("Update Class Successfull");
        }
        [HttpGet("GetClassById")]
        public IActionResult GetClassById(int id)
        {
           var classs = classRepository.GetClassById(id);
            return Ok(classs);
        }
        [HttpGet("GetClassesWithoutStudent")]
        public IActionResult GetClassesWithoutStudent()
        {
            var classes = classRepository.GetClassesWithoutStudent();
            return Ok(classes);
        }

    }
}
