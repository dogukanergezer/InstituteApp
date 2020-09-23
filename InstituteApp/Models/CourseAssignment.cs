namespace InstituteApp.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
