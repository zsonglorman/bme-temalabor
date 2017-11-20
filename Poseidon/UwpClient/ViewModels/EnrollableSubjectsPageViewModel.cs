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


        private Subject selectedSubject;
        public Subject SelectedSubject { get { return selectedSubject; } }
    }
}
