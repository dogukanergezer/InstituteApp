﻿namespace InstituteApp.Models
{
    public class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}
