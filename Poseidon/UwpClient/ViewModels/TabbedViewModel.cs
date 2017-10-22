using System;

using GalaSoft.MvvmLight;
using UwpClient.Models;
using System.Collections.ObjectModel;
using UwpClient.Services;

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
    }
}
