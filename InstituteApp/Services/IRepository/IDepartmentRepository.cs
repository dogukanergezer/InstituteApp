using InstituteApp.Models;
using System.Collections.Generic;

namespace InstituteApp.Services.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> InstructorToDepartments();

        Department InstructorToDepartment(int id);
    }
}
