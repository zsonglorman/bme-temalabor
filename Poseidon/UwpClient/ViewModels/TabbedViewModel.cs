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
        }

        public ObservableCollection<SubjectDataPoint> Source
        {
            get
            {
                return SubjectService.GetChartSampleData();
            }
        }

        public ObservableCollection<Grade> GradeSource
        {
            get
            {
                return SubjectService.GetSubjectsBySemester(1);
            }
        }

        public ObservableCollection<SubjectDataPoint> GradeSample
        {
            get
            {
                return SubjectService.TabChartSample(1);
            }
        }

    }
}
