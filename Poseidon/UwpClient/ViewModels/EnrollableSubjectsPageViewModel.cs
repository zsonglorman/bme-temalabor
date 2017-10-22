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
        //public ObservableCollection<SampleOrder> Source
        //{
        //    get
        //    {
        //        // TODO WTS: Replace this with your actual data
        //        return SampleDataService.GetGridSampleData();
        //    }
        //}

        public ObservableCollection<Subject> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SubjectService.GetGridSubjectData();
            }
        }
    }
}
