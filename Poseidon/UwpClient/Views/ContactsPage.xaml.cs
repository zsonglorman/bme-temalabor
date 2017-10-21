using System;

using UwpClient.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class ContactsPagePage : Page
    {
        private ContactsPageViewModel ViewModel
        {
            get { return DataContext as ContactsPageViewModel; }
        }

        public ContactsPagePage()
        {
            InitializeComponent();
        }
    }
}
