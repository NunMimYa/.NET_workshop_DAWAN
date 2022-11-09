namespace ContosoUniversity.Models.SchoolViewModels
{
    public class AssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}

/*
 * The AssignedCourseData class contains data 
 * to create the checkboxes for courses assigned to an instructor.
 */