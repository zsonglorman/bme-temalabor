using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;


using UwpClient.Services;
using Interfaces;
using UwpClient.Models;

namespace UwpClient.ViewModels
{
    public class EnrollableSubjectsPageViewModel : ViewModelBase
    {
        public EnrollableSubjectsPageViewModel()
        {
            subjectSource = SubjectService.GetGridSubjectData();

            subjectWithGradeSource = SubjectService.GetSubjectsBySemester(1);

            subjectAndGradeSource = SubjectService.GetTabbedPage(subjectWithGradeSource);
        }

        public ObservableCollection<Subject> subjectSource;

        public ObservableCollection<Subject> SubjectSource
        {
            get
            {
                // TODO WTS: Replace this with your actual data
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

        public ObservableCollection<SubjectAndGrade> subjectAndGradeSource;

        public ObservableCollection<SubjectAndGrade> SubjectAndGradeSource
        {
            get
            {
                return subjectAndGradeSource;
            }
        }


        private Subject selectedSubject;
        public Subject SelectedSubject { get { return selectedSubject; } }
    }
}
