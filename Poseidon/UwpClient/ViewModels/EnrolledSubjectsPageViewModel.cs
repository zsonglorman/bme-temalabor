using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using UwpClient.Services;
using Mocks;
using Interfaces;

namespace UwpClient.ViewModels
{
    public class EnrolledSubjectsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Subject> Source
        {
            get
            {
                return SubjectService.GetGridSubjectData();
            }
        }
    }
}
