using System.Collections.Generic;

namespace Interfaces
{
    public class SubjectWithGrade
    {
        public Subject Subject { get; private set; }

        public Grade Grade { get; private set; }

        public SubjectWithGrade(Subject subject, Grade grade)
        {
            Subject = subject;
            Grade = grade;
        }
    }
}
