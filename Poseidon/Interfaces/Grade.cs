namespace Interfaces
{
    public class Grade
    {
        public int StudentID { get; set; }

        public int SubjectID { get; set; }

        public int EnrollmentSemenster { get; set; }

        public bool Signature { get; set; }

        public bool Passed { get; set; }

        public int ReceivedGrade { get; set; }

        public Grade(int studentID, int subjectID, int enrollmentSemenster, bool signature, bool passed, int receivedGrade)
        {
            StudentID = studentID;
            SubjectID = subjectID;
            EnrollmentSemenster = enrollmentSemenster;
            Signature = signature;
            Passed = passed;
            ReceivedGrade = receivedGrade;
        }
    }
}
