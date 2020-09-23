using InstituteApp.DAL;
using InstituteApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteApp.Services.Repository
{
    public class CourseAssignmentRepository : Repository<CourseAssignment>, ICourseAssignmentRepository
    {
        protected readonly InstituteContext Context;
        public CourseAssignmentRepository(InstituteContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<CourseAssignment>> CoursesToInstructorAsync(int id)
        {
            return await Context.CourseAssignments
                .Where(x => x.InstructorId == id)
                .Include(x => x.Course)
                .ToListAsync();
        }
    }
}
