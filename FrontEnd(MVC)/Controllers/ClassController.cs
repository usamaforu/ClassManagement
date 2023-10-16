using APIDTOs;
using Microsoft.AspNetCore.Mvc;
using MvcDAL.Interface;

namespace FrontEnd_MVC_.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository classRepository;
        public ClassController(IClassRepository _classRepository)
        {
            classRepository = _classRepository;
        }
        [HttpGet()]
        public ActionResult AddClass()
        {
            ClassDTOs classDTOs = new ClassDTOs();
            return View(classDTOs);
        }
        [HttpPost()]
        public ActionResult AddClass(ClassDTOs classDTOs)
        {
            classRepository.AddClass(classDTOs);
            return RedirectToAction("GetAllClasses");
        }
        [HttpGet()]
        public async Task<ActionResult> GetAllClasses()
        {
            var classes =  await classRepository.GetAllClasses();
            return View(classes);
        }
        public ActionResult Delete(int id)
        {
            classRepository.DeleteClass(id);
            return RedirectToAction("GetAllClasses");
        }
        public async Task<ActionResult> Edit(int id) 
        {
            var classs =await  classRepository.GetClassById(id);
            return View(classs);
        }
        [HttpPost()]
        public ActionResult Edit(ClassDTOs classDTOs)
        {
            classRepository.UpdateClass(classDTOs);
            return RedirectToAction("GetAllClasses");
        }
    }
}
