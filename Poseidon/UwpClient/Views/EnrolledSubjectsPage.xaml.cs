using Interfaces;
using System;
using Telerik.UI.Xaml.Controls.Grid;
using UwpClient.ViewModels;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class EnrolledSubjectsPagePage : Page
    {
        private EnrolledSubjectsPageViewModel ViewModel
        {
            get { return DataContext as EnrolledSubjectsPageViewModel; }
        }

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public EnrolledSubjectsPagePage()
        {
            InitializeComponent();
        }

        public Subject row;
        private void EnrolledGrid_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var physicalPoint = e.GetCurrentPoint(sender as RadDataGrid);
            var point = new Point { X = physicalPoint.Position.X, Y = physicalPoint.Position.Y };
            row = (Subject)(sender as RadDataGrid).HitTestService.RowItemFromPoint(point);
            var cell = (sender as RadDataGrid).HitTestService.CellInfoFromPoint(point);
        }

        private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            foreach (var item in ViewModel.SubjectSource)
            {
                if(item.Id == row.Id)
                {
                    ViewModel.SubjectSource.Remove(item);
                    ViewModel.RaisePropertyChanged();
                }
            }
        }
    }
}
