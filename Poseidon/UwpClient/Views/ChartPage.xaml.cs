using System;

using UwpClient.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpClient.Views
{
    public sealed partial class ChartPage : Page
    {
        private ChartViewModel ViewModel
        {
            get { return DataContext as ChartViewModel; }
        }

        // TODO: UWPTemplates: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartPage()
        {
            InitializeComponent();
            // CredtiPerSemesterChart.VerticalAxis.TitleTemplate = this.Resources["19970427"] as DataTemplate;
            //CredtiPerSemesterChart.VerticalAxis.Style = this.Resources["owntitlestyle"] as Style;
        }
    }
}
