using System;

using UwpClient.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class StartPagePage : Page
    {
        private StartPageViewModel ViewModel
        {
            get { return DataContext as StartPageViewModel; }
        }

        public StartPagePage()
        {
            InitializeComponent();
        }
    }
}
