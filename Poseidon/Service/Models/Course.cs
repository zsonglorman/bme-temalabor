namespace Service.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public string Location { get; set; }
        public string Schedule { get; set; }
        public int LengthInMinutes { get; set; }
        public string CourseType { get; set; }

        public Subject Subject { get; set; }
    }
}
