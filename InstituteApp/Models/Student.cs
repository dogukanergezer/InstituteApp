using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstituteApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public Gender Gender { get; set; }
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:dd,MM,yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
