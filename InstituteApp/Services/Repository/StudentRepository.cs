using InstituteApp.DAL;
using InstituteApp.Models;
using InstituteApp.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InstituteApp.Services.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        protected InstituteContext Context;
        public StudentRepository(InstituteContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Enrollment> CoursesToStudent(int studentId)
        {
            return Context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(x => x.Student)
                .Include(x => x.Course)
                .ToList();
        }
    }
}
