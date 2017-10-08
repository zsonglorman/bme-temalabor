using System.Collections.Generic;

namespace Interfaces
{
    public interface ISubjectManager
    {
        List<Subject> GetSubjects();

        List<Subject> SearchSubjects(string keyword);

        List<Course> GetCoursesOfSubject(int subjectId);

        List<Grade> GetGradesOfSemester(int semester);
    }
}