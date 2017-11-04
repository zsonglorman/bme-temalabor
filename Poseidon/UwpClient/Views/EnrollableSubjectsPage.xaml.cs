using System;
using Telerik.UI.Xaml.Controls.Grid;
using UwpClient.ViewModels;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class EnrollableSubjectsPagePage : Page
    {
        private EnrollableSubjectsPageViewModel ViewModel
        {
            get { return DataContext as EnrollableSubjectsPageViewModel; }
        }

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public EnrollableSubjectsPagePage()
        {
            InitializeComponent();
        }

        private void grid_PointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var physicalPoint = e.GetCurrentPoint(sender as RadDataGrid);
            var point = new Point { X = physicalPoint.Position.X, Y = physicalPoint.Position.Y };
            var row = (sender as RadDataGrid).HitTestService.RowItemFromPoint(point);
            var cell = (sender as RadDataGrid).HitTestService.CellInfoFromPoint(point);
        }

        private void Details_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailsPage));
            
        }
    }
}
