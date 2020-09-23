using InstituteApp.Models;
using System.Collections.Generic;

namespace InstituteApp.ViewModels
{
    public class EditCreateViewModel
    {
        public Instructor Instructor { get; set; }
        public List<AssignedCourseData> AssignedCourseData { get; set; }
    }
}
