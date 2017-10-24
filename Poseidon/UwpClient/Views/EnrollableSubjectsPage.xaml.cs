using System;

using UwpClient.ViewModels;

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

        private void grid_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailsPage));
        }
    }
}
