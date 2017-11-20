using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using UwpClient.Services;
using Mocks;
using Interfaces;
using UwpClient.Models;

namespace UwpClient.ViewModels
{
    public class EnrolledSubjectsPageViewModel : ViewModelBase
    {
        public EnrolledSubjectsPageViewModel()
        {
            subjectSource = SubjectService.GetGridSubjectData();

            subjectWithGradeSource = SubjectService.GetSubjectsBySemester(1);

            subjectAndGradeSouce = SubjectService.GetTabbedPage(subjectWithGradeSource);
        }

        public ObservableCollection<Subject> subjectSource;

        public ObservableCollection<Subject> SubjectSource
        {
            get
            {
                return subjectSource;
                //return SubjectService.GetGridSubjectData();
            }
        }

        public ObservableCollection<SubjectWithGrade> subjectWithGradeSource;

        public ObservableCollection<SubjectWithGrade> SubjectWithGrade
        {
            get
            {
                return subjectWithGradeSource;
            }
        }

        public ObservableCollection<SubjectAndGrade> subjectAndGradeSouce;

        public ObservableCollection<SubjectAndGrade> SubjectAndGradeSource
        {
            get
            {
                return subjectAndGradeSouce;
            }
        }

    }
}
