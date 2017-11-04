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
            Interfaces.ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();

            ObservableCollection<Subject> data = new ObservableCollection<Subject>(subjectManager.GetSubjects());

            return data;
        }

        public static ObservableCollection<SubjectWithGrade> GetSubjectsBySemester(int semester)
        {
            //TODO:  elkérni a jó subjectmanagert és meghívni rajta az Interfacesben lévő fgv-t ha kész
            Interfaces.ISubjectManager subjectManager = Mocks.Factory.SubjectManagerFactory.GetSubjectManager();

            ObservableCollection<SubjectWithGrade> data = new ObservableCollection<SubjectWithGrade>(subjectManager.GetSubjectsWithGradesOfSemester(semester));

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
