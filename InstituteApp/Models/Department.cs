using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public decimal Budget { get; set; }

        public int? InstructorId { get; set; } //It may or may not be a department manager.
        [Display(Name = "Administrator")]
        public Instructor Instructor { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
