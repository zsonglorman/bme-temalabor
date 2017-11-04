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

        public ObservableCollection<SubjectWithGrade> GradeSource
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
                //Fül 2 levő diagram
                return SubjectService.TabChartSample(1);
            }
        }

    }
}
