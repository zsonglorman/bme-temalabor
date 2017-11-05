using System;
using UwpClient.Services;
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

        private void SemesterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            if (comboBoxItem == null) return;
            var content = comboBoxItem.Content as string;
            var name = comboBoxItem.Name as string;
            if (name != null && name.Equals("FirstSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(1));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(1);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
                
            }
            else if(name != null && name.Equals("SecondSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                //ViewModel.SubjectAndGradeSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(2));
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(2));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(2);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
            else if (name != null && name.Equals("ThirdSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(3));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(3);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
            else if (name != null && name.Equals("FourthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(4));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(4);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
            else if (name != null && name.Equals("FifthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectService.GetSubjectsBySemester(5);
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(5));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(5);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
            else if (name != null && name.Equals("SixthSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(6));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(6);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
            else if (name != null && name.Equals("SeventhSemester"))
            {
                //TODO: meghívni az adatbázisból lehívó fgv-t az adott félévre, frissíteni a gridet
                SubjectPerSemesterGrid.ItemsSource = SubjectService.GetTabbedPage(SubjectService.GetSubjectsBySemester(7));
                SubjectPerSemesterGrid.InvalidateArrange();
                SubjectPerSemesterGrid.UpdateLayout();

                ChartContent.ItemsSource = SubjectService.TabChartSample(7);
                ChartContent.InvalidateArrange();
                ChartContent.UpdateLayout();
            }
        }
    }
}
