using InstituteApp.Models;
using InstituteApp.Services;
using InstituteApp.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InstituteApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository, IInstructorRepository instructorRepository)
        {
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.InstructorToDepartments();
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = _departmentRepository.InstructorToDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Instructors = _instructorRepository.GetAll();
            return View();
        }

        public void InstructorList()
        {
            ViewBag.Instructors = _instructorRepository.GetAll();

        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Department model)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(model);
            }

            return RedirectToAction("Details", new { id = model.Id });

        }

        public IActionResult Edit(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            InstructorList();
            return View(department);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(Department model)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(model);
                return RedirectToAction("Details", new { id = model.Id });
            }

            return View("Edit");

        }

        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.InstructorToDepartment(id);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            _departmentRepository.Delete(department);
            return RedirectToAction("Index");

        }

    }
}
