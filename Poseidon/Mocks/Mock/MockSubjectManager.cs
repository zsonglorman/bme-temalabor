using System;
using System.Collections.Generic;
using Interfaces;

namespace Mocks.Factory
{
    public class MockSubjectManager : ISubjectManager
    {
        // TODO tárolja magának a tárgyakat, hogy a változásokat tudjuk követni (törlés, módosítás, insert)

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

        public List<SubjectWithGrade> GetSubjectsWithGradesOfSemester(int semester)
        {
            var subject1 = new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek");

            var grade1 = new Grade(1, 1, 1, true, false, 1);

            var subject2 = new Subject(2, "Elgondolkodtató tárgy", "DEF456", 5, 2, "Prof János");
            var grade2 = new Grade(1, 2, 1, true, true, 5);

            var subjectsWithGrades = new List<SubjectWithGrade>
            {
                new SubjectWithGrade(subject1, grade1),
                new SubjectWithGrade(subject2, grade2)
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

        public List<SubjectWithGrade> GetSubjectsWithGrades()
        {
            var subject1 = new Subject(1, "Teszt tárgy", "ABC123", 4, 1, "Teszt Elek");

            var grade1 = new Grade(1, 1, 1, true, false, 1);

            

            var subjectsWithGrades = new List<SubjectWithGrade>
            {
                new SubjectWithGrade(subject1, grade1)
            };

            return subjectsWithGrades;

        }
    }
}