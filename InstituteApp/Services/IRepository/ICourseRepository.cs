using InstituteApp.Models;
using System.Collections.Generic;

namespace InstituteApp.Services.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> CoursesToDepartment();
    }
}
