using System;

using GalaSoft.MvvmLight;
using UwpClient.Models;
using System.Collections.ObjectModel;
using UwpClient.Services;
using Interfaces;

namespace UwpClient.ViewModels
{
    public class TabbedViewModel : ViewModelBase
    {
        public TabbedViewModel()
        {
            subjectWithGradeSource = SubjectService.GetSubjectsBySemester(1);
        }

        ObservableCollection<SubjectWithGrade> subjectWithGradeSource;

        public ObservableCollection<SubjectWithGrade> SubjectWithGradeSource
        {
            get
            {
                return subjectWithGradeSource;
                //return SubjectService.GetSubjectsBySemester(1);
            }
        }

        public ObservableCollection<SubjectAndGrade> SubjectAndGradeSource
        {
            get
            {
                return SubjectService.GetTabbedPage(subjectWithGradeSource);
            }
        }

        

        public ObservableCollection<SubjectDataPoint> GradeSample
        {
            get
            {
                //Fül 2 levő diagram
                return SubjectService.TabChartSample(1);
            }
        }

    }
}
