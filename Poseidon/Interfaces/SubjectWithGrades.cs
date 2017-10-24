using System.Collections.Generic;

namespace Interfaces
{
    public class SubjectWithGrades
    {
        public Subject Subject { get; private set; }

        public List<Grade> Grades { get; private set; }

        public SubjectWithGrades(Subject subject, List<Grade> grades)
        {
            Subject = subject;
            Grades = grades;
        }
    }
}
