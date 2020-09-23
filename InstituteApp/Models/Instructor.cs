using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApp.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
