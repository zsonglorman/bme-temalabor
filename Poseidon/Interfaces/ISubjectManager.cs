using System.Collections.Generic;

namespace Interfaces
{
    public interface ISubjectManager
    {
        /// <summary>
        /// Get all subjects (without grades).
        /// </summary>
        /// <returns></returns>
        List<Subject> GetSubjects();

        /// <summary>
        /// Search subjects based on keyword (serach by subject name or subject code).
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<Subject> SearchSubjects(string keyword);

        /// <summary>
        /// Get all courses of a subject based on its subject ID.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        List<Course> GetCoursesOfSubject(int subjectId);

        /// <summary>
        /// Get subjects with their grades of a semester (each subject has exactly one grade).
        /// </summary>
        /// <param name="semester"></param>
        /// <returns></returns>
        List<SubjectWithGrade> GetSubjectsWithGradesOfSemester(int semester);

        /// <summary>
        /// Insert a new grade for a subject.
        /// </summary>
        /// <param name="grade"></param>
        void InsertGradeOfSubject(Grade grade);

        /// <summary>
        /// Update a grade of a subject. You may update Signature, Passed and ReceivedGrade fields.
        /// </summary>
        /// <param name="grade"></param>
        void UpdateGradeOfSubject(Grade grade);

        /// <summary>
        /// Deletes a grade from a subject. Grade is deleted based on its StudentID, SubjectID and EnrollmentSemester.
        /// </summary>
        /// <param name="grade"></param>
        void DeleteGradeOfSubject(Grade grade);

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        List<SubjectWithGrade> GetSubjectsWithGrades();

        /// <summary>
        /// Get all grades of a subject based on its SubjectID.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        List<Grade> GetGradesOfSubject(int subjectId);
    }
}