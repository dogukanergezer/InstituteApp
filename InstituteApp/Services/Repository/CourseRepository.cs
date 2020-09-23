using InstituteApp.DAL;
using InstituteApp.Models;
using InstituteApp.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InstituteApp.Services.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        protected readonly InstituteContext Context;

        public CourseRepository(InstituteContext context) : base(context)
        {
            Context = context;
        }


        public IEnumerable<Course> CoursesToDepartment()
        {
            return Context.Courses.Include(x => x.Department).ToList();
        }

    }
}
