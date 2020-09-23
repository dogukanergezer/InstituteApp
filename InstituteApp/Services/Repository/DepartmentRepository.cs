using InstituteApp.DAL;
using InstituteApp.Models;
using InstituteApp.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InstituteApp.Services.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(InstituteContext context) : base(context)
        {
            Context = context;
        }
        protected InstituteContext Context;


        public IEnumerable<Department> InstructorToDepartments()
        {
            return Context.Departments.Include(x => x.Instructor).ToList();

        }

        public Department InstructorToDepartment(int id)
        {
            //    //return  (from department in LeLeContext.Departments
            //    //    join instructor in LeLeContext.Instructors on department.Id equals instructor.Id
            //    //    select department).FirstOrDefault(x=>x.DepartmentId ==id);
            return Context.Departments.Include(x => x.Instructor).FirstOrDefault(x => x.Id == id);
        }




    }
}
