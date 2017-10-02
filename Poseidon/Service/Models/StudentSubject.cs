namespace Service.Models
{ 

    public class StudentSubject
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int EnrollmentSemenster { get; set; }
        public bool Signature { get; set; }
        public bool Passed { get; set; }
        public int Grade { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
