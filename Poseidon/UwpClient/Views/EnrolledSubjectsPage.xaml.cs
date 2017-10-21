using System;

using UwpClient.ViewModels;

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
    }
}
