using System;
using System.Collections.Generic;
using Interfaces;

namespace Mocks.Factory
{
    public class MockSubjectManager : ISubjectManager
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

        public List<SubjectWithGrades> GetSubjectsWithGradesOfSemester(int semester)
        {
            var subject1 = new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek");

            var grades1 = new List<Grade>()
            {                
                new Grade(1, 1, 1, true, false, 1),
                new Grade(1, 1, 2, true, true, 4)
            };

            var subject2 = new Subject(2, "Elgondolkodtató tárgy", "DEF456", 5, 2, "Prof János");
            var grades2 = new List<Grade>()
            {
                new Grade(1, 2, 1, true, true, 5)
            };

            var subjectsWithGrades = new List<SubjectWithGrades>
            {
                new SubjectWithGrades(subject1, grades1),
                new SubjectWithGrades(subject2, grades2)
            };

            return subjectsWithGrades;
        }

        public List<Subject> GetSubjectsWithGrades(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<Grade> GetGradesOfSubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void InsertGradeOfSubject(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void UpdateGradeOfSubject(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void DeleteGradeOfSubject(Grade grade)
        {
            throw new NotImplementedException();
        }
    }
}