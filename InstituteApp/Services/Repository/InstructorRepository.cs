using InstituteApp.DAL;
using InstituteApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstituteApp.Services.Repository
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        protected InstituteContext Context;
        public InstructorRepository(InstituteContext context) : base(context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Instructor>> InstructorsAsync()
        {
            return await Context.Instructors
                .Include(o => o.OfficeAssignment)
                .Include(ca => ca.CourseAssignments)
                    .ThenInclude(c => c.Course)
                       .ThenInclude(d => d.Department)
                .Include(ca => ca.CourseAssignments)
                    .ThenInclude(C => C.Course)
                       .ThenInclude(e => e.Enrollments)
                          .ThenInclude(s => s.Student)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Instructor> InstructorAsync(int id)
        {
            return await Context.Instructors
                .Include(x => x.CourseAssignments)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(x => x.InstructorId == id);
        }
    }
}
