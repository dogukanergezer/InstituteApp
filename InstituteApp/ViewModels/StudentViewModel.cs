using InstituteApp.Models;
using System.Collections.Generic;

namespace InstituteApp.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public Enrollment Enrollment { get; set; }

    }
}
