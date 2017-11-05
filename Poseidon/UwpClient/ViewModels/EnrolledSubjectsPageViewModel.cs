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

    }
}
