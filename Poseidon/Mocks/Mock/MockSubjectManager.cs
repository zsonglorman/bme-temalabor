using System;
using System.Collections.Generic;
using Interfaces;

namespace Mocks.Factory
{
    class MockSubjectManager : ISubjectManager
    {
        public List<Subject> GetSubjects()
        {
            return new List<Subject>()
            {
                new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek"),
                new Subject(2, "Elgondolkodtató tárgy", "DEF456", 5, 2, "Prof János")
            };
        }

        public List<Subject> SearchSubjects(string keyword)
        {
            return new List<Subject>()
            {
                new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek"),
                new Subject(2, "Elgondolkodtató tárgy", "DEF456", 5, 2, "Prof János")
            };
        }

        public List<Course> GetCoursesOfSubject(int subjectId)
        {
            return new List<Course>()
            {
                new Course(1, 1, "Q-I", "kedd, 08:15", 90, "Előadás"),
                new Course(2, 1, "R4L", "szerda, 10:15", 90, "Labor")
            };
        }

        public List<Grade> GetGradesOfSemester(int semester)
        {
            return new List<Grade>()
            {
                new Grade(1, 1, 1, true, true, 4),
                new Grade(1, 2, 1, true, false, 1)
            };
        }
    }
}