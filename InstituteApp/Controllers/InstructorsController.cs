using InstituteApp.Models;
using InstituteApp.Services;
using InstituteApp.Services.IRepository;
using InstituteApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteApp.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseAssignmentRepository _courseAssignmentRepository;

        public InstructorsController(IInstructorRepository instructorRepository, ICourseRepository courseRepository,
            ICourseAssignmentRepository courseAssignmentRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _courseAssignmentRepository = courseAssignmentRepository;
        }

        [Route("Instructors/Index/{id?}")]
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var allInstructors = await _instructorRepository.InstructorsAsync();
            var model = new InstructorViewModel()
            {
                Instructors = allInstructors
            };
            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;
                var instructor = model.Instructors.FirstOrDefault(x => x.InstructorId == id);
                if (instructor != null)
                    model.Courses = instructor.CourseAssignments.Select(s => s.Course); //LinqPad kullanıldı.
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;
                model.Enrollments = model.Courses.FirstOrDefault(x => x.Id == courseId)?.Enrollments;
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _instructorRepository.InstructorAsync((int)id);
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var allCourses = _courseRepository.GetAll();
            var model = new EditCreateViewModel()
            {
                AssignedCourseData = allCourses.Select(s => new AssignedCourseData()
                {
                    CourseId = s.Id,
                    CourseName = s.CourseName,
                    Assigned = false
                }).ToList()
            };
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(EditCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (model.Instructor != null)
            {
                _instructorRepository.Add(model.Instructor);

                var instructorId = model.Instructor.InstructorId;

                foreach (var data in model.AssignedCourseData)
                {
                    if (data.Assigned)
                    {
                        _courseAssignmentRepository.Add(new CourseAssignment()
                        {
                            CourseId = data.CourseId,
                            InstructorId = instructorId
                        });
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = _instructorRepository.GetById((int)id);
            var allCourses = _courseRepository.GetAll();
            var coursesToInstructor = await _courseAssignmentRepository
                .CoursesToInstructorAsync(instructor.InstructorId);
            var model = new EditCreateViewModel()
            {
                Instructor = instructor,
                AssignedCourseData = allCourses.Select(s => new AssignedCourseData()
                {
                    CourseId = s.Id,
                    CourseName = s.CourseName,
                    Assigned = coursesToInstructor.Exists(e => e.Course.Id == s.Id)
                }).ToList()

            };
            return View(model);
        }
        [HttpPost, ActionName("Edit")]

        public async Task<IActionResult> EditPost(EditCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _instructorRepository.Update(model.Instructor);
            var instructorId = model.Instructor.InstructorId;
            foreach (var data in model.AssignedCourseData)
            {
                if (data.Assigned)
                {
                    var IsExist = IsExistModel(_courseAssignmentRepository.GetAll()
                        , instructorId, data.CourseId);
                    if (!IsExist)
                    {
                        _courseAssignmentRepository.Add(new CourseAssignment()
                        {
                            CourseId = data.CourseId,
                            InstructorId = instructorId
                        });
                    }
                }
                else
                {
                    var IsExist = IsExistModel(_courseAssignmentRepository.GetAll()
                        , instructorId, data.CourseId);
                    if (IsExist)
                    {
                        var filter = _courseAssignmentRepository
                            .GetByFiler(x => x.InstructorId == instructorId && x.CourseId == data.CourseId)
                            .FirstOrDefault();
                        _courseAssignmentRepository.Delete(filter);
                    }

                }
            }

            return RedirectToAction("Index");

        }

        private bool IsExistModel(IEnumerable<CourseAssignment> source, int instructorId, int courseId)
        {
            return source.Where(x => x.InstructorId == instructorId).Any(c => c.CourseId == courseId);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _instructorRepository.InstructorAsync((int)id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? instructorId)
        {
            var instructor = _instructorRepository.GetById((int)instructorId);
            if (instructor == null && instructorId == null)
            {
                return NotFound();
            }
            _instructorRepository.Delete(instructor);
            return RedirectToAction("Index");
        }
    }
}
