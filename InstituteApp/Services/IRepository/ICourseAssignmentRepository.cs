using InstituteApp.Models;
using InstituteApp.Services.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstituteApp.Services
{
    public interface ICourseAssignmentRepository : IRepository<CourseAssignment>

    {
        Task<List<CourseAssignment>> CoursesToInstructorAsync(int id);
    }
}
