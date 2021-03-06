﻿using System;

using GalaSoft.MvvmLight;
using UwpClient.Models;
using System.Collections.ObjectModel;
using UwpClient.Services;
using Interfaces;
using Telerik.UI.Xaml.Controls.Grid.Commands;

namespace UwpClient.ViewModels
{
    public class TabbedViewModel : ViewModelBase
    {
        public TabbedViewModel()
        {
            subjectWithGradeSource = SubjectService.GetSubjectsBySemester(1);

            subjectAndGradeSource = SubjectService.GetTabbedPage(subjectWithGradeSource);
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

        public ObservableCollection<SubjectAndGrade> subjectAndGradeSource;

        public ObservableCollection<SubjectAndGrade> SubjectAndGradeSource
        {
            get
            {
                return subjectAndGradeSource;
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
