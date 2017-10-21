using System;

using UwpClient.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class TabbedPage : Page
    {
        private TabbedViewModel ViewModel
        {
            get { return DataContext as TabbedViewModel; }
        }

        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
