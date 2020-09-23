using InstituteApp.Models;
using System.Collections.Generic;

namespace InstituteApp.Services.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Enrollment> CoursesToStudent(int studentId);

    }
}
