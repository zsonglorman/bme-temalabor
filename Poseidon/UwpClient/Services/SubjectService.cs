using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mocks;
using UwpClient.Models;

namespace UwpClient.Services
{
    public static class SubjectService
    {

        private static IEnumerable<Subject> AllOrders()
        {
            Mocks.Factory.SubjectManagerFactory.Mocking = false;

            Interfaces.ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();

            ObservableCollection<Subject> data = new ObservableCollection<Subject>(subjectManager.GetSubjects());

            return data;
        }

        public static ObservableCollection<SubjectWithGrade> GetSubjectsBySemester(int semester)
        {
            //TODO:  elkérni a jó subjectmanagert és meghívni rajta az Interfacesben lévő fgv-t ha kész
            Mocks.Factory.SubjectManagerFactory.Mocking = false;

            Interfaces.ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();

            ObservableCollection<SubjectWithGrade> data = new ObservableCollection<SubjectWithGrade>(subjectManager.GetSubjectsWithGradesOfSemester(semester));

            return data;
        }

        public static ObservableCollection<SubjectAndGrade> GetTabbedPage(ObservableCollection<SubjectWithGrade> collection)
        {
            ObservableCollection<SubjectAndGrade> data = new ObservableCollection<SubjectAndGrade>();

            foreach (var item in collection)
            {
                int id = item.Subject.Id;
                string name = item.Subject.Name;
                string code = item.Subject.Code;
                int credit = item.Subject.Credit;
                int recommendedSemester = item.Subject.RecommendedSemester;
                string responsibleProfessor = item.Subject.ResponsibleProfessor;

                int studentID = item.Grade.StudentID;
                int subjectID = item.Grade.SubjectID;
                int enrollmentSemester = item.Grade.EnrollmentSemester;
                bool signature = item.Grade.Signature;
                bool passed = item.Grade.Passed;
                int receivedGrade = item.Grade.ReceivedGrade;

                SubjectAndGrade temp = new SubjectAndGrade(id, name,code,credit,recommendedSemester, responsibleProfessor,studentID,subjectID,enrollmentSemester,signature,passed,receivedGrade);

                data.Add(temp);
            }

            return data;

        }

        public static ObservableCollection<Course> GetCourseBySubject(int subjectid)
        {
            Mocks.Factory.SubjectManagerFactory.Mocking = false;

            Interfaces.ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();

            ObservableCollection<Course> data = new ObservableCollection<Course>(subjectManager.GetCoursesOfSubject(subjectid));

            return data;
        }

        public static ObservableCollection<SubjectDataPoint> TabChartSample(int semester)
        {
            var data = GetSubjectsBySemester(semester).Select(s => new SubjectDataPoint()
            {
                Semester = s.Grade.EnrollmentSemester, ReceivedGrade = s.Grade.ReceivedGrade
            }).OrderBy(dp => dp.Semester);

            return new ObservableCollection<SubjectDataPoint>(data);
        }

        public static ObservableCollection<Subject> GetGridSubjectData()
        {
            return new ObservableCollection<Subject>(AllOrders());
        }

        public static ObservableCollection<SubjectDataPoint> GetChartSampleData()
        {
            var data = AllOrders().Select(o => new SubjectDataPoint() { Credit = o.Credit, Semester = o.RecommendedSemester })
                                  .OrderBy(dp => dp.Semester);

            return new ObservableCollection<SubjectDataPoint>(data);
        }
    }
}
