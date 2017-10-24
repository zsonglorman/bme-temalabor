using System.Collections.Generic;

namespace Interfaces
{
    public interface ISubjectManager
    {
        // grade-ek nem kellenek
        List<Subject> GetSubjects();

        // grade-ek nem kellenek
        List<Subject> SearchSubjects(string keyword);

        List<Course> GetCoursesOfSubject(int subjectId);

        // grade-ek is benne vannak
        List<SubjectWithGrades> GetSubjectsWithGradesOfSemester(int semester);

        void InsertGradeOfSubject(Grade grade);

        void UpdateGradeOfSubject(Grade grade);

        void DeleteGradeOfSubject(Grade grade);

        List<Subject> GetSubjectsWithGrades(int studentId);

        List<Grade> GetGradesOfSubject(int subjectId);
    }
}